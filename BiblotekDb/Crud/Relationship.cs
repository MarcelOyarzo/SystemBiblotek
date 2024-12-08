using System;
using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;
using libraryDb.Models;

public class Relationship
{
    public static void Run()
    {
        using (var context = new AppDbContext())
        {
            var books = context.Books.ToList();

            if(books.Any())
            {
            foreach (var book in books)
            {
                System.Console.WriteLine($"Book ID {book.BookID} Title {book.Title} ");
            }
            }
            else 
            {
                System.Console.WriteLine("There is no book! ");
            } 

        var Authors = context.Authors.ToList();
        
            if(Authors.Any())
            {
            foreach (var Author in Authors)
            {
                System.Console.WriteLine($"Author ID {Author.AuthorID} Name {Author.FirstName} {Author.LastName} ");
            }
            }
            else 
            {
                System.Console.WriteLine("There is no author! ");
            } 


            System.Console.Write("Enter Book ID ");

            if (!int.TryParse(Console.ReadLine(), out var bookID))
            {
                System.Console.WriteLine("Invalid BookID ");
            }

            System.Console.Write("Enter Author ID ");

            if (!int.TryParse(Console.ReadLine(), out var AuthorID))
            {
                System.Console.WriteLine("Invalid Author ID ");
            }

            var bookAuthor = new Borrower
            {
                BookID = bookID, AuthorID = AuthorID
            };

            context.Borrowers.Add(bookAuthor);
            context.SaveChanges();
            System.Console.WriteLine("It been saved ");
            
        }
    }
}