using System.ComponentModel.DataAnnotations;

namespace KomürcüPeyzaj.Models;

public class Referans
{
    public int Id { get; set; }

    [Required] public string AdSoyad { get; set; } = string.Empty;
    public string Unvan { get; set; } = string.Empty;
    public string Sehir { get; set; } = string.Empty;
    [Required] public string Yorum { get; set; } = string.Empty;
    public int Puan { get; set; } = 5;
    public string ProjeAdi { get; set; } = string.Empty;
    public string FotoUrl { get; set; } = string.Empty;
    public string FirmaAdi { get; set; } = string.Empty;
    public string FirmaLogoUrl { get; set; } = string.Empty;
    public bool KurumsalMi { get; set; } = false;
    public bool YayindaMi { get; set; } = true;
    public DateTime Tarih { get; set; } = DateTime.Now;
}
