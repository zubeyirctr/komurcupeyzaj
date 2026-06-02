using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KomürcüPeyzaj.Data;

namespace KomürcüPeyzaj.Controllers;

[Route("blog")]
public class BlogController : Controller
{
    private readonly AppDbContext _db;
    private const int SayfaBasi = 6;

    public BlogController(AppDbContext db) => _db = db;

    [HttpGet("")]
    public async Task<IActionResult> Index(int sayfa = 1)
    {
        var query = _db.BlogYazilari.Where(b => b.YayindaMi).OrderByDescending(b => b.YayinTarihi);
        int toplam = await query.CountAsync();
        int toplamSayfa = (int)Math.Ceiling(toplam / (double)SayfaBasi);

        var yazilar = await query.Skip((sayfa - 1) * SayfaBasi).Take(SayfaBasi).ToListAsync();

        ViewBag.MevcutSayfa = sayfa;
        ViewBag.ToplamSayfa = toplamSayfa;

        return View(yazilar);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Detay(int id)
    {
        var yazi = await _db.BlogYazilari.FindAsync(id);
        if (yazi == null) return NotFound();

        yazi.OkunmaSayisi++;
        await _db.SaveChangesAsync();

        ViewBag.BenzerYazilar = await _db.BlogYazilari
            .Where(b => b.YayindaMi && b.Id != id)
            .OrderByDescending(b => b.YayinTarihi)
            .Take(3)
            .ToListAsync();

        return View(yazi);
    }
}
