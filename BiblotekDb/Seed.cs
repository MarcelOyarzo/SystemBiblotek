using System;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Microsoft.EntityFrameworkCore;
using libraryDb.Models;

public class Seed
{
        public static void Run()
        {
                using (var context = new AppDbContext())
                {
                        var transaction = context.Database.BeginTransaction();

                        try
                        {
                                if (!context.Books.Any() && !context.Authors.Any() && !context.Borrowers.Any())
                                {
                                        var book1 = new Book
                                        {
                                                Title = "Yotsuba&!",
                                                IssueDate = new DateOnly(2003, 03, 21),
                                                QuickBorrow = true
                                        };

                                        var book2 = new Book
                                        {
                                                Title = "Goodnight Punpun",
                                                IssueDate = new DateOnly(2007, 03, 15),
                                                QuickBorrow = true
                                        };

                                        var book3 = new Book
                                        {
                                                Title = "86: Eighty-Six",
                                                IssueDate = new DateOnly(2017, 02, 10),
                                                QuickBorrow = true
                                        };

                                        var book4 = new Book
                                        {
                                                Title = "Kare Kano: His and Her Circumstances",
                                                IssueDate = new DateOnly(1995, 12, 22),
                                                QuickBorrow = true
                                        };

                                        var book5 = new Book
                                        {
                                                Title = "Fruits Basket",
                                                IssueDate = new DateOnly(1998, 07, 18),
                                                QuickBorrow = true
                                        };


                                        var author1 = new Author
                                        {
                                                FirstName = "Azuma",
                                                LastName = "Kiyohikooki",
                                        };

                                        var author2 = new Author
                                        {
                                                FirstName = "Inio",
                                                LastName = "Asano",
                                        };

                                        var author3 = new Author
                                        {
                                                FirstName = "Asato",
                                                LastName = "Asato",
                                        };

                                        var author4 = new Author
                                        {
                                                FirstName = "Masami",
                                                LastName = "Tsuda",
                                        };

                                        var author5 = new Author
                                        {
                                                FirstName = "Natsuki",
                                                LastName = "Takaya",
                                        };

                                        context.Authors.Add(author1);
                                        context.Authors.Add(author2);
                                        context.Authors.Add(author3);
                                        context.Authors.Add(author4);
                                        context.Authors.Add(author5);

                                        context.Books.Add(book1);
                                        context.Books.Add(book2);
                                        context.Books.Add(book3);
                                        context.Books.Add(book4);
                                        context.Books.Add(book5);

                                        context.SaveChanges();

                var bookAuthors = new[]
                {
                        new Borrower {Book = book1, Author = author1},
                        new Borrower {Book = book2, Author = author2},
                        new Borrower {Book = book3, Author = author3},
                        new Borrower {Book = book4, Author = author4},
                        new Borrower {Book = book5, Author = author5}
                };

                                        context.Borrowers.AddRange(bookAuthors);
                                        context.SaveChanges();
                                        transaction.Commit();
                                        System.Console.WriteLine("Saved!");
                                }
                                else
                                {
                                        System.Console.WriteLine("The seed has already been applied");
                                }
                        }
                        catch (Exception ex)
                        {
                                transaction.Rollback();
                                System.Console.WriteLine("Error" + ex.Message);
                        }
                }
        }
}