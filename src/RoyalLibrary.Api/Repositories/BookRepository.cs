using Microsoft.EntityFrameworkCore;
using RoyalLibrary.Api.Data;
using RoyalLibrary.Api.Models;

namespace RoyalLibrary.Api.Repositories;

public class BookRepository : IBookRepository
{
    private readonly LibraryDbContext _context;
    private readonly ILogger<BookRepository> _logger;

    public BookRepository(LibraryDbContext context, ILogger<BookRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<IEnumerable<Book>> GetBooksAsync()
    {
        _logger.LogDebug("Retrieving all books");
        return await _context.Books.ToListAsync();
    }

    public async Task<IEnumerable<Book>> GetBooksByAuthorAsync(string author)
    {
        _logger.LogDebug("Retrieving books by author: {Author}", author);
        
        return await _context.Books
            .Where(b => (b.FirstName + " " + b.LastName).ToLower().Contains(author.ToLower()))
            .ToListAsync();
    }

    public async Task<IEnumerable<Book>> GetBooksByIsbnAsync(string isbn)
    {
        _logger.LogDebug("Retrieving books by ISBN: {Isbn}", isbn);
        
        return await _context.Books
            .Where(b => b.Isbn != null && b.Isbn.StartsWith(isbn))
            .ToListAsync();
    }

    public async Task<Book?> GetBookByIdAsync(int id)
    {
        _logger.LogDebug("Retrieving book by ID: {Id}", id);
        
        return await _context.Books
            .FirstOrDefaultAsync(b => b.BookId == id);
    }

    public async Task<int> GetBooksCountAsync()
    {
        _logger.LogDebug("Retrieving total books count");
        return await _context.Books.CountAsync();
    }

    public async Task<IEnumerable<Book>> GetBooksPagedAsync(int page, int pageSize)
    {
        _logger.LogDebug("Retrieving books page {Page} with size {PageSize}", page, pageSize);
        
        return await _context.Books
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }
}
