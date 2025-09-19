namespace RoyalLibrary.Api.Dtos;

public class BookResultDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Publisher { get; set; }
    public string Authors { get; set; } = string.Empty; // "FirstName LastName"
    public string? Type { get; set; }
    public string? Isbn { get; set; }
    public string? Category { get; set; }
    public string AvailableCopies { get; set; } = string.Empty; // "available/total" format
}
