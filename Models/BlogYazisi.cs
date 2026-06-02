using System.ComponentModel.DataAnnotations;

namespace KomürcüPeyzaj.Models;

public class BlogYazisi
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Başlık zorunludur")]
    [Display(Name = "Başlık")]
    public string Baslik { get; set; } = string.Empty;

    [Required(ErrorMessage = "İçerik zorunludur")]
    [Display(Name = "İçerik")]
    public string Icerik { get; set; } = string.Empty;

    [Display(Name = "Kısa Açıklama")]
    public string KisaAciklama { get; set; } = string.Empty;

    [Display(Name = "Kapak Görsel URL")]
    public string KapakGorsel { get; set; } = string.Empty;

    [Display(Name = "Yayın Tarihi")]
    public DateTime YayinTarihi { get; set; } = DateTime.Now;

    [Display(Name = "Yazar")]
    public string Yazar { get; set; } = "Kömürcü Peyzaj";

    [Display(Name = "Etiketler (virgülle ayırın)")]
    public string Etiketler { get; set; } = string.Empty;

    [Display(Name = "Yayında mı?")]
    public bool YayindaMi { get; set; } = true;

    [Display(Name = "Okunma Sayısı")]
    public int OkunmaSayisi { get; set; }
}
