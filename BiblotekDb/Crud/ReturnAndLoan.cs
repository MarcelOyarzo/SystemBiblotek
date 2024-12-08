
using libraryDb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Azure.Core.Pipeline;


public class ReturnAndLoan
{
    public static void Run()
    {
        using (var context = new AppDbContext())
        {
            System.Console.WriteLine("\nReturn or Loan a book");
            System.Console.WriteLine("1. Return Book");
            System.Console.WriteLine("2. Loan Book");
            System.Console.WriteLine("3. Return back to the menu");

            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    ReturnBook();
                    break;
                case "2":
                     AddLoans();
                    break;
                case "3":
                    System.Console.WriteLine("Press any key to return back to the menu...");
                    Console.ReadLine();
                    return;
            }
        }
    }



    public static void AddLoans()
    {
        using (var context = new AppDbContext())
        {

            System.Console.WriteLine("\nBooks Available\n");
            var books = context.Books.Include(ba => ba.Borrowers) 
                .ThenInclude(ba => ba.Author)
                .ToList();

            if (!books.Any())
            {
                Console.WriteLine("Enter the Book ID you wish to delete ");
                return;
            }

            foreach (var bks in books)
            {
                Console.WriteLine($"Book ID: {bks.BookID}, Title: {bks.Title} Available: {(bks.QuickBorrow ? "Yes" : "No")}\n");
            }


            Console.Write("Enter the name of the loaner ");
            var loaner = Console.ReadLine();

            Console.Write("Enter Book ID ");
            if (!int.TryParse(Console.ReadLine(), out var bookID))
            {
                Console.WriteLine("This is an invalid Book ID ");
                return;
            }

            var book = context.Books.Find(bookID);
            if (book == null)
            {
                Console.WriteLine("The book was not found ");
                return;
            }

            if (!book.QuickBorrow)
            {
                System.Console.WriteLine("The book is currently unavailable ");
                return;
            }
            var loan = new Loan
            {
                BookID = bookID,
                LoanName = loaner,
                LoanDate = DateTime.Now,
                ComeBack = false
            };

            context.Loans.Add(loan);
            context.SaveChanges();

            Console.WriteLine($"Loan added: {bookID} loaner: {loaner} ");
        }
    }


    public static void ReturnBook()
    {
        using (var context = new AppDbContext())
        {
            Console.Write("Enter the name of the loaner ");
            var loaner = Console.ReadLine();

            Console.Write("Enter the Book ID to return ");
            if (!int.TryParse(Console.ReadLine(), out var bookID))
            {
                Console.WriteLine("There is no Book ID for this ");
                return;
            }

            var loan = context.Loans
                .FirstOrDefault(l => l.LoanName == loaner && l.BookID == bookID && !l.ComeBack);

            if (loan == null)
            {
                Console.WriteLine("This loaner does not have any loans ");
                return;
            }

            loan.ComeBack = true;
            loan.ReturnDate = DateTime.Now;


            var book = context.Books.Find(bookID);
            if (book != null)
            {
                book.QuickBorrow = true;
            }

            context.SaveChanges();
            Console.WriteLine($"Loaner: {loaner} has returned Book ID: {bookID} ");
        }
    }
}
