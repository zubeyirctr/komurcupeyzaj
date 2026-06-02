using System.ComponentModel.DataAnnotations;

namespace KomürcüPeyzaj.Models;

public class SiteAyarlari
{
    public int Id { get; set; }

    [Display(Name = "Firma Adı")]
    public string FirmaAdi { get; set; } = "Kömürcü Peyzaj";

    [Display(Name = "Slogan")]
    public string Slogan { get; set; } = "Manzara Katıyoruz";

    [Display(Name = "Telefon")]
    public string Telefon { get; set; } = "0530 096 70 91";

    [Display(Name = "E-posta")]
    public string Email { get; set; } = "— Yakında —";

    [Display(Name = "Adres")]
    public string Adres { get; set; } = "— Yakında —";

    [Display(Name = "Hakkımızda Metni")]
    public string HakkimizdaMetni { get; set; } = "Kömürcü Peyzaj hakkında bilgiler yakında eklenecektir.";

    [Display(Name = "Tamamlanan Proje Sayısı")]
    public int TamamlananProje { get; set; } = 0;

    [Display(Name = "Mutlu Müşteri Sayısı")]
    public int MutluMusteri { get; set; } = 0;

    [Display(Name = "Deneyim Yılı")]
    public int DeneyimYili { get; set; } = 0;

    [Display(Name = "Google Maps Embed Kodu")]
    public string GoogleMapsEmbed { get; set; } = "";

    [Display(Name = "Instagram URL")]
    public string Instagram { get; set; } = "#";

    [Display(Name = "Facebook URL")]
    public string Facebook { get; set; } = "#";

    [Display(Name = "WhatsApp Numarası (wa.me/...)")]
    public string WhatsApp { get; set; } = "https://wa.me/905300967091";

    [Display(Name = "TikTok URL")]
    public string TikTok { get; set; } = "#";
}
