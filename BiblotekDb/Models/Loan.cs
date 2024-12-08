using System.Collections.Generic;
using System.Dynamic;
using Microsoft.Identity.Client;

namespace libraryDb.Models
{
    public class Loan
    {
        public int LoanID {get; set;}
        public int BookID {get; set;}
        
        public DateTime LoanDate {get; set;}
        public DateTime ReturnDate {get; set;}

        public bool ComeBack {get; set;}
        public string LoanName {get; set;}

        public Book Book {get; set;}
    }
}

/*
Loan
LoanID (int, not null ) (PK)
BookID (int, not null) (FK)
LoanDate (Date, Not null) 
ReturnDate (Date, not null)
ComeBack (Boolean, deafult false) 
LoanName (Varchar, not null)¨

*/