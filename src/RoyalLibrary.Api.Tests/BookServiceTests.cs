using Microsoft.Extensions.Logging;
using Moq;
using RoyalLibrary.Api.Dtos;
using RoyalLibrary.Api.Models;
using RoyalLibrary.Api.Services;

namespace RoyalLibrary.Api.Tests;

public class BookServiceTests
{
    [Fact]
    public void BookResultDto_ShouldHaveCorrectProperties()
    {
        // Arrange & Act
        var bookDto = new BookResultDto
        {
            Id = 1,
            Title = "Test Book",
            Publisher = "Test Publisher",
            Authors = "Test Author",
            Type = "Hardcover",
            Isbn = "1234567890",
            Category = "Fiction",
            AvailableCopies = "5/10"
        };

        // Assert
        Assert.Equal(1, bookDto.Id);
        Assert.Equal("Test Book", bookDto.Title);
        Assert.Equal("Test Publisher", bookDto.Publisher);
        Assert.Equal("Test Author", bookDto.Authors);
        Assert.Equal("Hardcover", bookDto.Type);
        Assert.Equal("1234567890", bookDto.Isbn);
        Assert.Equal("Fiction", bookDto.Category);
        Assert.Equal("5/10", bookDto.AvailableCopies);
    }

    [Fact]
    public void BookSearchDto_ShouldHaveDefaultValues()
    {
        // Arrange & Act
        var searchDto = new BookSearchDto();

        // Assert
        Assert.Equal(1, searchDto.Page);
        Assert.Equal(10, searchDto.PageSize);
        Assert.Null(searchDto.Author);
        Assert.Null(searchDto.Isbn);
        Assert.Null(searchDto.Status);
    }

    [Fact]
    public void PagedResult_ShouldInitializeCorrectly()
    {
        // Arrange & Act
        var pagedResult = new PagedResult<BookResultDto>
        {
            Items = new List<BookResultDto>(),
            Total = 0,
            Page = 1,
            PageSize = 10
        };

        // Assert
        Assert.NotNull(pagedResult.Items);
        Assert.Equal(0, pagedResult.Total);
        Assert.Equal(1, pagedResult.Page);
        Assert.Equal(10, pagedResult.PageSize);
    }

    [Fact]
    public void Book_ShouldHaveCorrectProperties()
    {
        // Arrange & Act
        var book = new Book
        {
            BookId = 1,
            Title = "Test Book",
            FirstName = "Test",
            LastName = "Author",
            TotalCopies = 10,
            CopiesInUse = 5,
            Type = "Hardcover",
            Isbn = "1234567890",
            Category = "Fiction",
            Publisher = "Test Publisher",
            OwnershipStatus = "own"
        };

        // Assert
        Assert.Equal(1, book.BookId);
        Assert.Equal("Test Book", book.Title);
        Assert.Equal("Test", book.FirstName);
        Assert.Equal("Author", book.LastName);
        Assert.Equal(10, book.TotalCopies);
        Assert.Equal(5, book.CopiesInUse);
        Assert.Equal("Hardcover", book.Type);
        Assert.Equal("1234567890", book.Isbn);
        Assert.Equal("Fiction", book.Category);
        Assert.Equal("Test Publisher", book.Publisher);
        Assert.Equal("own", book.OwnershipStatus);
    }
}
