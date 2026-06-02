using System.ComponentModel.DataAnnotations;

namespace KomürcüPeyzaj.Models;

public class Urun
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Ad zorunludur")]
    [Display(Name = "Ürün Adı")]
    public string Ad { get; set; } = string.Empty;

    [Required(ErrorMessage = "Açıklama zorunludur")]
    [Display(Name = "Açıklama")]
    public string Aciklama { get; set; } = string.Empty;

    [Display(Name = "Kısa Açıklama")]
    public string KisaAciklama { get; set; } = string.Empty;

    [Display(Name = "Görsel URL")]
    public string GorselUrl { get; set; } = string.Empty;

    [Display(Name = "Fiyat (₺)")]
    public decimal Fiyat { get; set; }

    [Display(Name = "Kategori")]
    public string Kategori { get; set; } = string.Empty;

    [Display(Name = "Aktif mi?")]
    public bool AktifMi { get; set; } = true;

    [Display(Name = "Stok Var mı?")]
    public bool StokVarMi { get; set; } = true;

    [Display(Name = "Sıra")]
    public int Sira { get; set; }
}
