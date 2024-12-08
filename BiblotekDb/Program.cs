using System;
using System.Dynamic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.SqlServer;
using libraryDb.Models;

class MainProgram
{
    static void Main(string[] args)
    {   
        Console.WriteLine("Welcome to the library\n");
        int menuSel = 0;
        do
        {
            menuSel = MenuS();
            Menu(menuSel);
        }
        while (menuSel != 7);
    }
    private static int MenuS()
    {
        int menuSel = 0;
            Console.WriteLine("Library Management Menu");
            Console.WriteLine("1. Create a New Book or make new Author");
            Console.WriteLine("2. Borrow or Return a Book");
            Console.WriteLine("3. Modify Book or Author Details");
            Console.WriteLine("4. Associate an Author with a Book");
            Console.WriteLine("5. Remove an  Author, Book, or Loan Record");
            Console.WriteLine("6. Display All Records");
            Console.WriteLine("7. Exit the Library");

        try
        {
            menuSel = Convert.ToInt32(Console.ReadLine());
            if (menuSel < 1 || menuSel > 7)
            {
                Console.WriteLine("Select Between 1 - 7");
                Console.ReadLine();
                return MenuS();
            }
        }
        catch
        {
            System.Console.WriteLine("Select between 1 - 7");
            Console.ReadLine();
            return MenuS(); 
        }
        return menuSel;
    }
    private static void Menu(int menuSel)
    {
        switch (menuSel)
        {
            case 1:
                Add.Run();
                break;
            case 2:
                ReturnAndLoan.Run();
                break;
            case 3:
                Update.Run();
                break;
            case 4:
                Relationship.Run();
                break;
            case 5:
                Remove.Run();
                break;
            case 6:
                List.Run();
                break;
            case 7:
                System.Console.WriteLine("See you later space cowboy...");
                menuSel = 0;   
                return;
            default:
                System.Console.WriteLine("Wrong characters...");
                Console.ReadLine();
                break;
        }
    }
}