using System.ComponentModel.DataAnnotations;

namespace KomürcüPeyzaj.Models;

public class EkipUyesi
{
    public int Id { get; set; }

    [Display(Name = "Ad Soyad")]
    public string AdSoyad { get; set; } = string.Empty;

    [Display(Name = "Ünvan")]
    public string Unvan { get; set; } = string.Empty;

    [Display(Name = "Biyografi")]
    public string Biyografi { get; set; } = string.Empty;

    [Display(Name = "Fotoğraf URL")]
    public string FotoUrl { get; set; } = string.Empty;

    [Display(Name = "Sıra")]
    public int Sira { get; set; }
}
