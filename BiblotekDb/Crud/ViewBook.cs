using System;
using Microsoft.EntityFrameworkCore;
using libraryDb.Models;

public class ViewBook
{
    public static void Run()
    {
        using (var context = new AppDbContext())
        {
            var books = context.Books.Include(b => b.Borrowers)
                .ThenInclude(b => b.Author)
                .ToList();

            if (books.Any())
            {


                foreach (var book in books)
                {
                    System.Console.WriteLine($"Book Title {book.Title} ");
                    foreach (var author in book.Borrowers)
                    {
                        System.Console.WriteLine($"Aurthor ID: {author.AuthorID} Aurthor Name: {author.Author.FirstName} {author.Author.LastName}");
                    }
                }
            }
            else
            {
                System.Console.WriteLine("There is no reltionship! ");
            }
        }
    }
}