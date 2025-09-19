using Microsoft.AspNetCore.Mvc;
using RoyalLibrary.Api.Dtos;
using RoyalLibrary.Api.Services;

namespace RoyalLibrary.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;
    private readonly ILogger<BooksController> _logger;

    public BooksController(IBookService bookService, ILogger<BooksController> logger)
    {
        _bookService = bookService;
        _logger = logger;
    }

    /// <summary>
    /// Search books with optional filters and pagination
    /// </summary>
    /// <param name="author">Search by author name (searches in first name + last name)</param>
    /// <param name="isbn">Search by ISBN prefix</param>
    /// <param name="status">Search by status (to be implemented)</param>
    /// <param name="page">Page number (default: 1)</param>
    /// <param name="pageSize">Page size (default: 10, max: 100)</param>
    /// <returns>Paginated list of books</returns>
    [HttpGet]
    [ProducesResponseType(typeof(PagedResult<BookResultDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<PagedResult<BookResultDto>>> GetBooks(
        [FromQuery] BookSearchDto searchDto)
    {
        _logger.LogInformation("Books search requested with parameters: {@SearchDto}", searchDto);

        // Validate model
        if (!ModelState.IsValid)
        {
            _logger.LogWarning("Invalid search parameters provided: {@ModelState}", ModelState);
            return BadRequest(ModelState);
        }

        try
        {
            var result = await _bookService.SearchBooksAsync(searchDto);
            
            _logger.LogInformation("Books search completed successfully. Found {Count} books", result.Items.Count);
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while searching books");
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request");
        }
    }
}
