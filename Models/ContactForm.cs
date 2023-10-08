using System.ComponentModel.DataAnnotations;

namespace Crito.Models;

public class ContactForm
{
    [Required]
    public string Name { get; set; } = null!;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required]
    public string Message { get; set; } = null!;

    public string? RedirectUrl { get; set; } = "/";
}
