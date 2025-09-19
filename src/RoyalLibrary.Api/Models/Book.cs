using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoyalLibrary.Api.Models;

public class Book
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BookId { get; set; }

    [Required]
    [MaxLength(100)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string LastName { get; set; } = string.Empty;

    public int TotalCopies { get; set; } = 0;

    public int CopiesInUse { get; set; } = 0;

    [MaxLength(50)]
    public string? Type { get; set; }

    [MaxLength(80)]
    public string? Isbn { get; set; }

    [MaxLength(50)]
    public string? Category { get; set; }

    [MaxLength(100)]
    public string? Publisher { get; set; }

    [MaxLength(20)]
    public string? OwnershipStatus { get; set; } // "own", "love", "want to read"
}
