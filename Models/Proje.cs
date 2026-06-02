using System.ComponentModel.DataAnnotations;

namespace KomürcüPeyzaj.Models;

public class Proje
{
    public int Id { get; set; }

    [Required] public string Ad { get; set; } = string.Empty;
    [Required] public string Aciklama { get; set; } = string.Empty;
    public string Konum { get; set; } = string.Empty;
    public DateTime TamamlanmaTarihi { get; set; }
    public string KapakGorsel { get; set; } = string.Empty;
    public string OncesiGorsel { get; set; } = string.Empty;
    public string SonrasiGorsel { get; set; } = string.Empty;
    public string Kategori { get; set; } = string.Empty;
    public bool OneIkartilsinMi { get; set; }

    public int HizmetId { get; set; }
    public Hizmet Hizmet { get; set; } = null!;
    public ICollection<ProjeGorsel> Gorseller { get; set; } = new List<ProjeGorsel>();
}
