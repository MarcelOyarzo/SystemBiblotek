using System.Collections.Generic;
using System.Dynamic;
using Microsoft.Identity.Client;

namespace libraryDb.Models
{
    public class Borrower
    {
        public int AuthorID {get; set;}
        public int BookID {get; set;}
        public int BorrowerID {get; set;}

        public Author Author {get; set;}
        public Book Book {get; set;}
    }
}

/*
Borrower(BookAuthor)
AuthorID (int, not null)(FK)
BookID (int, not null)(FK)
BorrowerID (int, not null)(PK)

*/