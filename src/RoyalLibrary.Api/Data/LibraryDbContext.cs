using Microsoft.EntityFrameworkCore;
using RoyalLibrary.Api.Models;

namespace RoyalLibrary.Api.Data;

public class LibraryDbContext : DbContext
{
    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Book>(entity =>
        {
            entity.ToTable("books");
            entity.HasKey(e => e.BookId);
            entity.Property(e => e.BookId).HasColumnName("book_id");
            entity.Property(e => e.Title).HasColumnName("title").IsRequired().HasMaxLength(100);
            entity.Property(e => e.FirstName).HasColumnName("first_name").IsRequired().HasMaxLength(50);
            entity.Property(e => e.LastName).HasColumnName("last_name").IsRequired().HasMaxLength(50);
            entity.Property(e => e.TotalCopies).HasColumnName("total_copies").HasDefaultValue(0);
            entity.Property(e => e.CopiesInUse).HasColumnName("copies_in_use").HasDefaultValue(0);
            entity.Property(e => e.Type).HasColumnName("type").HasMaxLength(50);
            entity.Property(e => e.Isbn).HasColumnName("isbn").HasMaxLength(80);
            entity.Property(e => e.Category).HasColumnName("category").HasMaxLength(50);
            entity.Property(e => e.Publisher).HasColumnName("publisher").HasMaxLength(100);
            entity.Property(e => e.OwnershipStatus).HasColumnName("ownership_status").HasMaxLength(20);
        });
    }
}
