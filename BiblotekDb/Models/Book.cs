using System.Collections.Generic;
using System.Dynamic;
using Microsoft.Identity.Client;

namespace libraryDb.Models
{
    public class Book
    {
        public int BookID {get; set;}
        public string Title {get; set;}
        
        public DateOnly IssueDate {get; set;}
        public bool QuickBorrow {get; set;}

        public ICollection<Borrower> Borrowers {get;set;}
        public ICollection<Loan> Loans {get; set;}
    }
}