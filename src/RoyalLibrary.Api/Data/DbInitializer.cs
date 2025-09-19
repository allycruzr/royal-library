using Microsoft.EntityFrameworkCore;
using RoyalLibrary.Api.Models;

namespace RoyalLibrary.Api.Data;

public static class DbInitializer
{
    public static async Task InitializeAsync(LibraryDbContext context)
    {
        // Database will be created by migrations
        // Clear existing data and recreate for testing
        await context.Books.ExecuteDeleteAsync();

        // Insert sample data
        var books = new List<Book>
        {
            new Book
            {
                Title = "Pride and Prejudice",
                FirstName = "Jane",
                LastName = "Austen",
                TotalCopies = 100,
                CopiesInUse = 80,
                Type = "Hardcover",
                Isbn = "1234567891",
                Category = "Fiction",
                Publisher = "Penguin Classics",
                OwnershipStatus = "own"
            },
            new Book
            {
                Title = "To Kill a Mockingbird",
                FirstName = "Harper",
                LastName = "Lee",
                TotalCopies = 75,
                CopiesInUse = 65,
                Type = "Paperback",
                Isbn = "1234567892",
                Category = "Fiction",
                Publisher = "HarperCollins",
                OwnershipStatus = "love"
            },
            new Book
            {
                Title = "The Catcher in the Rye",
                FirstName = "J.D.",
                LastName = "Salinger",
                TotalCopies = 50,
                CopiesInUse = 45,
                Type = "Hardcover",
                Isbn = "1234567893",
                Category = "Fiction",
                Publisher = "Little, Brown and Company",
                OwnershipStatus = "own"
            },
            new Book
            {
                Title = "The Great Gatsby",
                FirstName = "F. Scott",
                LastName = "Fitzgerald",
                TotalCopies = 50,
                CopiesInUse = 22,
                Type = "Hardcover",
                Isbn = "1234567894",
                Category = "Non-Fiction",
                Publisher = "Scribner",
                OwnershipStatus = "want to read"
            },
            new Book
            {
                Title = "The Alchemist",
                FirstName = "Paulo",
                LastName = "Coelho",
                TotalCopies = 50,
                CopiesInUse = 35,
                Type = "Hardcover",
                Isbn = "1234567895",
                Category = "Biography",
                Publisher = "HarperOne",
                OwnershipStatus = "own"
            },
            new Book
            {
                Title = "The Book Thief",
                FirstName = "Markus",
                LastName = "Zusak",
                TotalCopies = 75,
                CopiesInUse = 11,
                Type = "Hardcover",
                Isbn = "1234567896",
                Category = "Mystery",
                Publisher = "Knopf",
                OwnershipStatus = "love"
            },
            new Book
            {
                Title = "The Chronicles of Narnia",
                FirstName = "C.S.",
                LastName = "Lewis",
                TotalCopies = 100,
                CopiesInUse = 14,
                Type = "Paperback",
                Isbn = "1234567897",
                Category = "Sci-Fi",
                Publisher = "HarperCollins",
                OwnershipStatus = "own"
            },
            new Book
            {
                Title = "The Da Vinci Code",
                FirstName = "Dan",
                LastName = "Brown",
                TotalCopies = 50,
                CopiesInUse = 40,
                Type = "Paperback",
                Isbn = "1234567898",
                Category = "Sci-Fi",
                Publisher = "Doubleday",
                OwnershipStatus = "want to read"
            },
            new Book
            {
                Title = "The Grapes of Wrath",
                FirstName = "John",
                LastName = "Steinbeck",
                TotalCopies = 50,
                CopiesInUse = 35,
                Type = "Hardcover",
                Isbn = "1234567899",
                Category = "Fiction",
                Publisher = "Viking Press",
                OwnershipStatus = "own"
            },
            new Book
            {
                Title = "The Hitchhiker's Guide to the Galaxy",
                FirstName = "Douglas",
                LastName = "Adams",
                TotalCopies = 50,
                CopiesInUse = 35,
                Type = "Paperback",
                Isbn = "1234567900",
                Category = "Non-Fiction",
                Publisher = "Pan Books",
                OwnershipStatus = "love"
            },
            new Book
            {
                Title = "Moby-Dick",
                FirstName = "Herman",
                LastName = "Melville",
                TotalCopies = 30,
                CopiesInUse = 8,
                Type = "Hardcover",
                Isbn = "8901234567",
                Category = "Fiction",
                Publisher = "Harper & Brothers",
                OwnershipStatus = "want to read"
            },
            new Book
            {
                Title = "To Kill a Mockingbird",
                FirstName = "Harper",
                LastName = "Lee",
                TotalCopies = 20,
                CopiesInUse = 0,
                Type = "Paperback",
                Isbn = "9012345678",
                Category = "Non-Fiction",
                Publisher = "J.B. Lippincott & Co.",
                OwnershipStatus = "own"
            },
            new Book
            {
                Title = "The Catcher in the Rye",
                FirstName = "J.D.",
                LastName = "Salinger",
                TotalCopies = 10,
                CopiesInUse = 1,
                Type = "Hardcover",
                Isbn = "0123456789",
                Category = "Non-Fiction",
                Publisher = "Little, Brown and Company",
                OwnershipStatus = "love"
            }
        };

        await context.Books.AddRangeAsync(books);
        await context.SaveChangesAsync();
    }
}
