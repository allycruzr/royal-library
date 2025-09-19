using Microsoft.EntityFrameworkCore;
using RoyalLibrary.Api.Data;
using RoyalLibrary.Api.Dtos;
using RoyalLibrary.Api.Models;

namespace RoyalLibrary.Api.Services;

public class BookService : IBookService
{
    private readonly LibraryDbContext _context;
    private readonly ILogger<BookService> _logger;

    public BookService(LibraryDbContext context, ILogger<BookService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<PagedResult<BookResultDto>> SearchBooksAsync(BookSearchDto searchDto)
    {
        _logger.LogInformation("Searching books with parameters: {@SearchDto}", searchDto);

        try
        {
            // Validate and normalize search parameters
            var normalizedSearch = NormalizeSearchParameters(searchDto);

            // Build query
            var query = _context.Books.AsQueryable();

            // Apply filters
            query = ApplyAuthorFilter(query, normalizedSearch.Author);
            query = ApplyIsbnFilter(query, normalizedSearch.Isbn);
            query = ApplyOwnershipStatusFilter(query, normalizedSearch.Status);

            // Count total records
            var total = await query.CountAsync();

            // Apply pagination and projection
            var books = await query
                .Skip((normalizedSearch.Page - 1) * normalizedSearch.PageSize)
                .Take(normalizedSearch.PageSize)
                .ToListAsync();

            var bookDtos = books.Select(MapToBookResultDto).ToList();

            var result = new PagedResult<BookResultDto>
            {
                Items = bookDtos,
                Total = total,
                Page = normalizedSearch.Page,
                PageSize = normalizedSearch.PageSize
            };

            _logger.LogInformation("Found {Count} books out of {Total} total", bookDtos.Count, total);
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while searching books");
            throw;
        }
    }

    private static BookSearchDto NormalizeSearchParameters(BookSearchDto searchDto)
    {
        return new BookSearchDto
        {
            Author = string.IsNullOrWhiteSpace(searchDto.Author) ? null : searchDto.Author.Trim(),
            Isbn = string.IsNullOrWhiteSpace(searchDto.Isbn) ? null : searchDto.Isbn.Trim(),
            Status = string.IsNullOrWhiteSpace(searchDto.Status) ? null : searchDto.Status.Trim(),
            Page = Math.Max(1, searchDto.Page),
            PageSize = Math.Min(100, Math.Max(1, searchDto.PageSize))
        };
    }

    private static IQueryable<Book> ApplyAuthorFilter(IQueryable<Book> query, string? author)
    {
        if (string.IsNullOrEmpty(author))
            return query;

        return query.Where(b => 
            (b.FirstName + " " + b.LastName).ToLower().Contains(author.ToLower()));
    }

    private static IQueryable<Book> ApplyIsbnFilter(IQueryable<Book> query, string? isbn)
    {
        if (string.IsNullOrEmpty(isbn))
            return query;

        return query.Where(b => b.Isbn != null && b.Isbn.StartsWith(isbn));
    }

    private static IQueryable<Book> ApplyOwnershipStatusFilter(IQueryable<Book> query, string? status)
    {
        if (string.IsNullOrEmpty(status))
            return query;

        return query.Where(b => b.OwnershipStatus != null && 
                               b.OwnershipStatus.ToLower() == status.ToLower());
    }

    private static BookResultDto MapToBookResultDto(Book book)
    {
        var availableCopies = Math.Max(0, book.TotalCopies - book.CopiesInUse);
        
        return new BookResultDto
        {
            Id = book.BookId,
            Title = book.Title,
            Publisher = book.Publisher,
            Authors = $"{book.FirstName} {book.LastName}",
            Type = book.Type,
            Isbn = book.Isbn,
            Category = book.Category,
            AvailableCopies = $"{availableCopies}/{book.TotalCopies}"
        };
    }
}
