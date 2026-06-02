using System.ComponentModel.DataAnnotations;

namespace KomürcüPeyzaj.Models;

public class Hizmet
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Ad zorunludur")]
    [Display(Name = "Hizmet Adı")]
    public string Ad { get; set; } = string.Empty;

    [Required(ErrorMessage = "Açıklama zorunludur")]
    [Display(Name = "Açıklama")]
    public string Aciklama { get; set; } = string.Empty;

    [Display(Name = "Kısa Açıklama")]
    public string KisaAciklama { get; set; } = string.Empty;

    [Display(Name = "İkon (Bootstrap Icons)")]
    public string Ikon { get; set; } = "bi-tree";

    [Display(Name = "Görsel URL")]
    public string GorselUrl { get; set; } = string.Empty;

    [Display(Name = "Başlangıç Fiyatı (₺)")]
    public decimal BaslangicFiyati { get; set; }

    [Display(Name = "Aktif mi?")]
    public bool AktifMi { get; set; } = true;

    [Display(Name = "Sıra")]
    public int Sira { get; set; }

    public ICollection<Proje> Projeler { get; set; } = new List<Proje>();
}
