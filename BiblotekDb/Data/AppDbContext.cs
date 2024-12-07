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

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<Customer>()
    //         .HasOne(P=> P.Address)
    //         .WithMany(A => A.Customer)
    //         .HasForeignKey(P => P.AddressId);
    // }
}