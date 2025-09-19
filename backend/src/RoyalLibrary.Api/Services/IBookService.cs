using RoyalLibrary.Api.Dtos;

namespace RoyalLibrary.Api.Services;

public interface IBookService
{
    Task<PagedResult<BookResultDto>> SearchBooksAsync(BookSearchDto searchDto);
}
