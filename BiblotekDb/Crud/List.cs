using System;
using Microsoft.EntityFrameworkCore;
using libraryDb.Models;

public class List
{
    public static void Run()
    {
        using (var context = new AppDbContext())
        {
            while (true)
            {
                System.Console.WriteLine("View Library");
                System.Console.WriteLine("Do you want to view the library Yes/No");
                var _input = Console.ReadLine();
                if (_input == "No")
                {
                    System.Console.WriteLine("Press any key to go back to menu");
                    Console.ReadLine();
                    return;
                }
                
                else if (_input == "Yes")
                {
                    System.Console.WriteLine("\n1. View List Book");
                    System.Console.WriteLine("2. View Relations");
                    System.Console.WriteLine("3. View the List of Loan");
                    System.Console.WriteLine("4. Return to the Menu");
                

                    var _menuInput = Console.ReadLine();
                    switch (_menuInput)
                    {
                        case "1":
                            ListOfBook.Run();
                            break;
                        case "2":
                            ViewBook.Run();
                            break;
                        case "3":
                            ListOfLoan.Run();
                            break;
                        case "4":
                            System.Console.WriteLine("To Return back press any key ");
                            Console.ReadLine();
                            return;
                        default:
                            System.Console.WriteLine("Select between 1 - 4 ");  
                            Console.ReadLine();                      
                            break; 
                    }
                }
                else
                {
                    System.Console.WriteLine("Invalid input put a number from 1 - 4 ");
                    Console.ReadLine();       
                }
            }
        }
    }

public class ListOfBook
{
    public static void Run()
    {
        using(var context = new AppDbContext())
        {
            var Books = context.Books.Include(ba => ba.Borrowers)
                .ThenInclude(BookAuthor => BookAuthor.Author)
                .ToList();
            
            foreach (var Book in Books)
            {
                System.Console.WriteLine($"\nBook ID {Book.BookID} Book Title {Book.Title} {Book.IssueDate} ");
                foreach (var Author in Book.Borrowers)
                {
                    System.Console.WriteLine($"Author ID {Author.AuthorID} Author {Author.Author.FirstName} {Author.Author.LastName} ");
                }
            }
        }
    }
}
    public class ListOfLoan
    {
        public static void Run()
        {

            using (var context = new AppDbContext())
            {
                var loans = context.Loans.Include(l => l.Book)
                    .Where(l => l.ComeBack == false)
                    .ToList();

                if (!loans.Any())
                {
                    System.Console.WriteLine("There are no books that have been loaned ");
                }
                else
                {
                    foreach (var loan in loans)
                    {
                        System.Console.WriteLine($"\nBook: {loan.Book.Title}");
                        System.Console.WriteLine($"Signature: {loan.LoanName}");
                        System.Console.WriteLine($"Is Returned: {loan.ComeBack}");
                    }

                }
            }
        }
    }
}