using System;
using Microsoft.EntityFrameworkCore;
using libraryDb.Models;

public class Update
{
    public static void Run()
    {
        using (var context = new AppDbContext())
        {
            System.Console.WriteLine("\nUpdate Book and Author");
            System.Console.WriteLine("1. Edit the books");
            System.Console.WriteLine("2. Edit the Authors");
            System.Console.WriteLine("3. Return back to the menu");

            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    EditBook();
                    break;
                case "2":
                    EditAuthor();
                    break;
                case "4":
                    System.Console.WriteLine("Press any key to return back to the menu...");
                    Console.ReadLine();
                    return;
            }
        }
    }


    public static void EditBook()
    {
        using (var context = new AppDbContext())
        {
            var Books = context.Books.ToList();
            System.Console.WriteLine("Enter the Book ID ");
            
            if (!int.TryParse(Console.ReadLine(), out var bookID))
            {
                System.Console.WriteLine("The book ID was not found! ");
            
                foreach (var book in Books)
                {
                    System.Console.WriteLine($"Title {book.Title} BookID: {book.BookID} ");
                }
                return;
            }

            var updateBook = context.Books.Find(bookID);
            System.Console.WriteLine($"The book's title is currently {updateBook.Title}.\nEnter a new title to replace it.");
            var title = Console.ReadLine();
            
            if (!string.IsNullOrWhiteSpace(title))
            {
                updateBook.Title = title;
            }
            context.SaveChanges();
            System.Console.WriteLine($"Book successfully renamed to {title}.");
        }
    }



    public static void EditAuthor()
    {
        using (var context = new AppDbContext())
        {
            var Authors = context.Authors.ToList();
            System.Console.WriteLine("Enter the Author ID ");
            if (!int.TryParse(Console.ReadLine(), out var AuthorID))
            {
                System.Console.WriteLine("The ID was not found, please try again ");
                foreach (var Author in Authors)
                {
                    System.Console.WriteLine($"Author {Author.FirstName} {Author.LastName} ID: {Author.AuthorID} ");
                }
                return;
            }

            var updateAuthor = context.Authors.Find(AuthorID); 
            System.Console.WriteLine($"The current Author name is {updateAuthor.FirstName} {updateAuthor.LastName}");
            
            var firstName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(firstName)) 
            {
                updateAuthor.FirstName = firstName;
            }

            var lastName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(lastName))
            { 
                updateAuthor.LastName = lastName; 
            }

            context.SaveChanges();
            System.Console.WriteLine($"The name was updated to {firstName} {lastName} ");
        }
    }
}
