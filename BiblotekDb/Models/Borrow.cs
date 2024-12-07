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