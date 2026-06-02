using System.ComponentModel.DataAnnotations;

namespace KomürcüPeyzaj.Models;

public class ProjeGorsel
{
    public int Id { get; set; }

    [Display(Name = "Görsel URL")]
    public string GorselUrl { get; set; } = string.Empty;

    [Display(Name = "Başlık")]
    public string Baslik { get; set; } = string.Empty;

    public int ProjeId { get; set; }
    public Proje Proje { get; set; } = null!;
}
