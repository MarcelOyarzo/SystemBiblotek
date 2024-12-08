using libraryDb.Models;
using System;
using System.Linq;

public class Remove
{
    public static void Run()
    {
        using (var context = new AppDbContext())
        {
            System.Console.WriteLine("\nRemove Book, Author or Loan");
            System.Console.WriteLine("3. Delete Loan");
            System.Console.WriteLine("2. Delete Book");
            System.Console.WriteLine("1. Delete Author");

            System.Console.WriteLine("4. Return back to the menu");

            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    DeleteLoan();
                    break;
                case "2":
                    DeleteBook();
                    break;
                case "3":
                    DeleteAuthor();
                    break;
                case "4":
                    System.Console.WriteLine("Press any key to return back to the menu...");
                    Console.ReadLine();
                    return;
            }
        }
    }

    private static void DeleteLoan()
    {
        using (var context = new AppDbContext())
        {
            var loans = context.Loans.ToList();
            if (!loans.Any())
            {
                System.Console.WriteLine("No loans was found ");
            }
            else
            {
                foreach (var lend in loans) 
                {
                    System.Console.WriteLine($"Loan ID {lend.LoanID} Loaners IssueDate {lend.ComeBack}");
                }
            }

            Console.Write("Write Loan ID to delete ");
            if (int.TryParse(Console.ReadLine(), out var loanId))
            {
                var loan = context.Loans.Find(loanId);
                if (loan != null)
                {
                    context.Loans.Remove(loan);
                    context.SaveChanges();
                    Console.WriteLine("Loan has been deleted ");
                }
                else
                {
                    Console.WriteLine("Loan ID does not exist ");
                }
            }
        }
    }
    private static void DeleteBook()
    {
        using (var context = new AppDbContext())
        {

            var books = context.Books.ToList();
            if (!books.Any())
            {
                System.Console.WriteLine("No books could be found ");
            }
            else
            {
                foreach (var bock in books) 
                {
                    System.Console.WriteLine($"Book ID {bock.BookID} Title {bock.Title} ");
                }
            }

            System.Console.Write("Enter the Book ID you want to delete ");
            if (int.TryParse(Console.ReadLine(), out var bookid))
            {
                var book = context.Books.Find(bookid);
                if (book != null)
                {
                    var bookauthor_ = context.Borrowers.Where(ba => ba.BookID == bookid).ToList();
                    context.Borrowers.RemoveRange(bookauthor_);

                    context.Books.Remove(book);
                    context.SaveChanges();
                    System.Console.WriteLine("Book has been removed! ");
                }
                else
                {
                    Console.WriteLine("The Book was not found ");
                }
            }
        }
    }

    private static void DeleteAuthor()
    {
        using (var context = new AppDbContext())
        {
            var Authors = context.Authors.ToList();

            if (!Authors.Any())
            {
                System.Console.WriteLine("No authors was found ");
            } 
            else
            {
                foreach (var auth in Authors)
                {
                    System.Console.WriteLine($"Author ID {auth.AuthorID} Firstname {auth.FirstName} Lastname {auth.LastName} ");
                }
            }

            System.Console.Write("Enter Author ID to delete ");
            if (int.TryParse(Console.ReadLine(), out var AuthorID))
            {
                var Author = context.Authors.Find(AuthorID);
                if (Author != null)
                {
                    var bookauth = context.Borrowers.Where(ba => ba.AuthorID == AuthorID).ToList();
                    context.Borrowers.RemoveRange(bookauth);

                    context.Authors.Remove(Author);
                    context.SaveChanges();
                    Console.WriteLine("The author has been successfully deleted! ");
                }
            }
            else
            {
                Console.WriteLine("Author was not found ");
            }
        }
    }
}