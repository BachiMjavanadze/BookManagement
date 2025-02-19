using BookManagement.Core.Models;
using BookManagement.Infrastructure.Data.Seed;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Infrastructure.Data;

public class BookManagementDbContext : DbContext
{
    public BookManagementDbContext(DbContextOptions<BookManagementDbContext> options)
        : base(options)
    { }

    public DbSet<Book> Books { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Book>().HasData(BookSeedData.GetSeedData());
    }
}
