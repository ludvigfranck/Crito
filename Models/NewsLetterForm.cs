using System.ComponentModel.DataAnnotations;

namespace Crito.Models;

public class NewsLetterForm
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;
}
