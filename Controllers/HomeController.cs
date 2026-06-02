using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KomürcüPeyzaj.Data;
using KomürcüPeyzaj.Models;

namespace KomürcüPeyzaj.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _db;
    public HomeController(AppDbContext db) => _db = db;

    public async Task<IActionResult> Index()
    {
        ViewBag.Hizmetler = await _db.Hizmetler.Where(h => h.AktifMi).OrderBy(h => h.Sira).Take(6).ToListAsync();
        ViewBag.OneProjeler = await _db.Projeler.Where(p => p.OneIkartilsinMi).Include(p => p.Hizmet).Take(8).ToListAsync();
        ViewBag.OnceSonraPrje = await _db.Projeler.Where(p => p.OneIkartilsinMi && !string.IsNullOrEmpty(p.OncesiGorsel)).FirstOrDefaultAsync();
        ViewBag.SonBloglar = await _db.BlogYazilari.Where(b => b.YayindaMi).OrderByDescending(b => b.YayinTarihi).Take(3).ToListAsync();
        ViewBag.Ayarlar = await _db.SiteAyarlari.FirstOrDefaultAsync();
        ViewBag.Referanslar = await _db.Referanslar.Where(r => r.YayindaMi).OrderByDescending(r => r.Tarih).Take(6).ToListAsync();
        return View();
    }
}
