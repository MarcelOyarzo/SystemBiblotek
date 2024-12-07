using Microsoft.EntityFrameworkCore;
using libraryDb.Models;

public class AppDbContext : DbContext
{
    public DbSet<Author> Authors {get; set;}
    public DbSet<Book> Books {get; set;}
    public DbSet<Borrower> Borrowers {get; set;}
    public DbSet<Loan> Loans {get; set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=BiblotekDb;Trusted_Connection=True;");
    }

     protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Borrower>()
            .HasKey(ba => new {ba.BookID, ba.AuthorID }); 

        modelBuilder.Entity<Borrower>()
            .HasOne(ba => ba.Book)
            .WithMany(ba => ba.Borrowers)
            .HasForeignKey(ba => ba.BookID);
        
        modelBuilder.Entity<Borrower>()
            .HasOne(ba => ba.Author)
            .WithMany(ba => ba.Borrowers)
            .HasForeignKey(ba => ba.AuthorID);
        
        modelBuilder.Entity<Loan>()
            .HasKey(l => l.LoanID);
    }


}