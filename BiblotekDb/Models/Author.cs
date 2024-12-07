using System.Collections.Generic;
using System.Dynamic;
using Microsoft.Identity.Client;

namespace libraryDb.Models
{
    public class Author
    {
        public int AuthorID {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}

        public ICollection<Borrower> Borrowers {get; set;}
    }
}