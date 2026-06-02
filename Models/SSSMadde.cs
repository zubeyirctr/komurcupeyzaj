using System.ComponentModel.DataAnnotations;

namespace KomürcüPeyzaj.Models;

public class SSSMadde
{
    public int Id { get; set; }

    [Required] public string Soru { get; set; } = string.Empty;
    [Required] public string Cevap { get; set; } = string.Empty;
    public int Sira { get; set; }
    public bool AktifMi { get; set; } = true;
}
