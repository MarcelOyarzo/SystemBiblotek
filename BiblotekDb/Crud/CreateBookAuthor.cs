using System;
using Microsoft.EntityFrameworkCore.Storage.Json;
using libraryDb.Models;

public class Add
{
    public static void Run()
    {
        using (var context = new AppDbContext())
        {
                System.Console.WriteLine("\nAdd a New Book or Author");
                System.Console.WriteLine("1. Add Book");
                System.Console.WriteLine("2. Add Author");
                System.Console.WriteLine("3. Return to Previous Menu");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    AddBook();
                    break;
                case "2":
                    AddAuthor();
                    break;
                case "4":
                    System.Console.WriteLine("Return back to the menu press any key");
                    Console.ReadLine();
                    return;
            }
        }
    }
    public static void AddBook()
    {
        using (var context = new AppDbContext())
        {
            System.Console.WriteLine("Add a new Book to Library");

            System.Console.WriteLine("Enter Title");
            var _title = Console.ReadLine()?.Trim();

            System.Console.WriteLine("Enter Release Date YYYY MM DD (With space between)");
            var _issueDate = Console.ReadLine();
            if (!DateOnly.TryParse(_issueDate, out DateOnly issueDate))
            {
                System.Console.WriteLine("Invalid Input, try again!");
                return;
            }

            System.Console.WriteLine("Ready to loan!");
            bool _quickBorrow = true;

            var _book = new Book
            {
                Title = _title,
                IssueDate = issueDate,
                QuickBorrow = _quickBorrow
            };
            context.Books.Add(_book);
            context.SaveChanges();
            System.Console.WriteLine($"{_title} Has been added!"); 
        }
    }


    public static void AddAuthor()
    {
        using (var context = new AppDbContext())
        {
            System.Console.WriteLine("\nAdd a new Author\n");
            Console.ResetColor();

            System.Console.WriteLine("Enter a First Name: ");
            var _firstName = Console.ReadLine()?.Trim();
            System.Console.WriteLine("Enter a Last Name: ");
            var _lastName = Console.ReadLine()?.Trim();

            var _author = new Author 
            {
                FirstName = _firstName,
                LastName = _lastName,
            };

            context.Authors.Add(_author);
            context.SaveChanges();
            System.Console.WriteLine($"{_firstName} {_lastName} Has been added to the library\n");
        }
    }
}