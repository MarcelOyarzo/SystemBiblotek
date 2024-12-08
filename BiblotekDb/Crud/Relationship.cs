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
                System.Console.WriteLine("There is no book ");
            } 

        var Authors = context.Authors.ToList();
        
            if(Authors.Any())
            {
            foreach (var author in Authors)
            {
                System.Console.WriteLine($"Aurthor ID {author.AuthorID} Name {author.FirstName} {author.LastName} ");
            }
            }
            else 
            {
                System.Console.WriteLine("There is no author ");
            } 


            System.Console.Write("Enter Book ID ");

            if (!int.TryParse(Console.ReadLine(), out var bookID))
            {
                System.Console.WriteLine("Invalid BookID ");
            }

            System.Console.Write("Enter Aurthor ID ");

            if (!int.TryParse(Console.ReadLine(), out var authorID))
            {
                System.Console.WriteLine("Invalid Aurthor ID ");
            }

            var bookAuthor = new Borrower
            {
                BookID = bookID, AuthorID = authorID
            };

            context.Borrowers.Add(bookAuthor);
            context.SaveChanges();
            System.Console.WriteLine("Has been saved ");
            
        }
    }
}