using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KomürcüPeyzaj.Data;
using KomürcüPeyzaj.Models;

namespace KomürcüPeyzaj.Controllers.Admin;

[Route("admin/hizmetler")]
public class HizmetAdminController : Controller
{
    private readonly AppDbContext _db;

    public HizmetAdminController(AppDbContext db) => _db = db;

    [HttpGet("")]
    public async Task<IActionResult> Index()
        => View(await _db.Hizmetler.OrderBy(h => h.Sira).ToListAsync());

    [HttpGet("olustur")]
    public IActionResult Olustur() => View(new Hizmet());

    [HttpPost("olustur")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Olustur(Hizmet hizmet)
    {
        if (!ModelState.IsValid) return View(hizmet);
        _db.Hizmetler.Add(hizmet);
        await _db.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    [HttpGet("duzenle/{id}")]
    public async Task<IActionResult> Duzenle(int id)
    {
        var hizmet = await _db.Hizmetler.FindAsync(id);
        if (hizmet == null) return NotFound();
        return View(hizmet);
    }

    [HttpPost("duzenle/{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Duzenle(Hizmet hizmet)
    {
        if (!ModelState.IsValid) return View(hizmet);
        _db.Hizmetler.Update(hizmet);
        await _db.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    [HttpGet("sil/{id}")]
    public async Task<IActionResult> Sil(int id)
    {
        var hizmet = await _db.Hizmetler.FindAsync(id);
        if (hizmet == null) return NotFound();
        return View(hizmet);
    }

    [HttpPost("sil/{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SilOnayla(int id)
    {
        var hizmet = await _db.Hizmetler.FindAsync(id);
        if (hizmet != null)
        {
            _db.Hizmetler.Remove(hizmet);
            await _db.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }
}
