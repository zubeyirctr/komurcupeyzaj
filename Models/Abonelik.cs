using System.ComponentModel.DataAnnotations;

namespace KomürcüPeyzaj.Models;

public class Abonelik
{
    public int Id { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    public DateTime KayitTarihi { get; set; } = DateTime.Now;
}
