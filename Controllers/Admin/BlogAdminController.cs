using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KomürcüPeyzaj.Data;
using KomürcüPeyzaj.Models;

namespace KomürcüPeyzaj.Controllers.Admin;

[Route("admin/blog")]
public class BlogAdminController : Controller
{
    private readonly AppDbContext _db;

    public BlogAdminController(AppDbContext db) => _db = db;

    [HttpGet("")]
    public async Task<IActionResult> Index()
        => View(await _db.BlogYazilari.OrderByDescending(b => b.YayinTarihi).ToListAsync());

    [HttpGet("olustur")]
    public IActionResult Olustur() => View(new BlogYazisi { YayinTarihi = DateTime.Today });

    [HttpPost("olustur")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Olustur(BlogYazisi yazi)
    {
        if (!ModelState.IsValid) return View(yazi);
        _db.BlogYazilari.Add(yazi);
        await _db.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    [HttpGet("duzenle/{id}")]
    public async Task<IActionResult> Duzenle(int id)
    {
        var yazi = await _db.BlogYazilari.FindAsync(id);
        if (yazi == null) return NotFound();
        return View(yazi);
    }

    [HttpPost("duzenle/{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Duzenle(BlogYazisi yazi)
    {
        if (!ModelState.IsValid) return View(yazi);
        _db.BlogYazilari.Update(yazi);
        await _db.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    [HttpGet("sil/{id}")]
    public async Task<IActionResult> Sil(int id)
    {
        var yazi = await _db.BlogYazilari.FindAsync(id);
        if (yazi == null) return NotFound();
        return View(yazi);
    }

    [HttpPost("sil/{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SilOnayla(int id)
    {
        var yazi = await _db.BlogYazilari.FindAsync(id);
        if (yazi != null)
        {
            _db.BlogYazilari.Remove(yazi);
            await _db.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }
}
