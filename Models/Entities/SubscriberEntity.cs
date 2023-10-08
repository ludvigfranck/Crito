using System.ComponentModel.DataAnnotations;

namespace Crito.Models.Entities;

public class SubscriberEntity
{
    [Required]
    [Key]
    public string Email { get; set; } = null!;
}
