using System.ComponentModel.DataAnnotations;

namespace KomürcüPeyzaj.Models;

public class IletisimMesaji
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Ad Soyad zorunludur")]
    [Display(Name = "Ad Soyad")]
    public string AdSoyad { get; set; } = string.Empty;

    [Required(ErrorMessage = "E-posta zorunludur")]
    [EmailAddress(ErrorMessage = "Geçerli bir e-posta giriniz")]
    [Display(Name = "E-posta")]
    public string Email { get; set; } = string.Empty;

    [Display(Name = "Telefon")]
    public string Telefon { get; set; } = string.Empty;

    [Display(Name = "Konu")]
    public string Konu { get; set; } = string.Empty;

    [Required(ErrorMessage = "Mesaj zorunludur")]
    [Display(Name = "Mesaj")]
    public string Mesaj { get; set; } = string.Empty;

    [Display(Name = "Gönderim Tarihi")]
    public DateTime GonderimTarihi { get; set; } = DateTime.Now;

    [Display(Name = "Okundu mu?")]
    public bool OkunduMu { get; set; } = false;
}
