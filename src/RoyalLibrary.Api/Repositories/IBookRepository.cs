using RoyalLibrary.Api.Models;

namespace RoyalLibrary.Api.Repositories;

public interface IBookRepository
{
    Task<IEnumerable<Book>> GetBooksAsync();
    Task<IEnumerable<Book>> GetBooksByAuthorAsync(string author);
    Task<IEnumerable<Book>> GetBooksByIsbnAsync(string isbn);
    Task<Book?> GetBookByIdAsync(int id);
    Task<int> GetBooksCountAsync();
    Task<IEnumerable<Book>> GetBooksPagedAsync(int page, int pageSize);
}
