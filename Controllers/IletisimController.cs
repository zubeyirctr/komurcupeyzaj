using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KomürcüPeyzaj.Data;
using KomürcüPeyzaj.Models;

namespace KomürcüPeyzaj.Controllers;

[Route("iletisim")]
public class IletisimController : Controller
{
    private readonly AppDbContext _db;
    public IletisimController(AppDbContext db) => _db = db;

    [HttpGet("")]
    public async Task<IActionResult> Index()
    {
        ViewBag.Ayarlar = await _db.SiteAyarlari.FirstOrDefaultAsync();
        return View(new IletisimMesaji());
    }

    [HttpPost("")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Index(IletisimMesaji yeniMesaj)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Ayarlar = await _db.SiteAyarlari.FirstOrDefaultAsync();
            return View(yeniMesaj);
        }
        yeniMesaj.GonderimTarihi = DateTime.Now;
        _db.IletisimMesajlari.Add(yeniMesaj);
        await _db.SaveChangesAsync();
        return RedirectToAction(nameof(Tesekkurler));
    }

    [HttpGet("tesekkurler")]
    public IActionResult Tesekkurler() => View();

    [HttpPost("abone")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Abone(string email)
    {
        if (!string.IsNullOrEmpty(email) && !_db.Abonelikler.Any(a => a.Email == email))
        {
            _db.Abonelikler.Add(new Abonelik { Email = email });
            await _db.SaveChangesAsync();
        }
        TempData["AboneBasari"] = "Abone oldunuz!";
        return RedirectToAction(nameof(Index));
    }
}
