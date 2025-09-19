using System.ComponentModel.DataAnnotations;

namespace RoyalLibrary.Api.Dtos;

public class BookSearchDto
{
    [StringLength(100, ErrorMessage = "Author name cannot exceed 100 characters")]
    public string? Author { get; set; }

    [StringLength(80, ErrorMessage = "ISBN cannot exceed 80 characters")]
    public string? Isbn { get; set; }

    [StringLength(50, ErrorMessage = "Status cannot exceed 50 characters")]
    public string? Status { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Page must be greater than 0")]
    public int Page { get; set; } = 1;

    [Range(1, 100, ErrorMessage = "Page size must be between 1 and 100")]
    public int PageSize { get; set; } = 10;
}
