using System.ComponentModel.DataAnnotations;

namespace DiaryApp.Models;

public class DiaryEntry
{
    public int Id { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [MinLength(100, ErrorMessage = "The {0} must be at least {1} characters long.")]
    public string Content { get; set; } = string.Empty;

    [Required(ErrorMessage = "The Date field is required.")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}