using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KomürcüPeyzaj.Data;
using KomürcüPeyzaj.Models;

namespace KomürcüPeyzaj.Controllers.Admin;

[Route("admin/projeler")]
public class ProjeAdminController : Controller
{
    private readonly AppDbContext _db;

    public ProjeAdminController(AppDbContext db) => _db = db;

    [HttpGet("")]
    public async Task<IActionResult> Index()
        => View(await _db.Projeler.Include(p => p.Hizmet).ToListAsync());

    [HttpGet("olustur")]
    public async Task<IActionResult> Olustur()
    {
        ViewBag.Hizmetler = new SelectList(await _db.Hizmetler.ToListAsync(), "Id", "Ad");
        return View(new Proje { TamamlanmaTarihi = DateTime.Today });
    }

    [HttpPost("olustur")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Olustur(Proje proje)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Hizmetler = new SelectList(await _db.Hizmetler.ToListAsync(), "Id", "Ad");
            return View(proje);
        }
        _db.Projeler.Add(proje);
        await _db.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    [HttpGet("duzenle/{id}")]
    public async Task<IActionResult> Duzenle(int id)
    {
        var proje = await _db.Projeler.FindAsync(id);
        if (proje == null) return NotFound();
        ViewBag.Hizmetler = new SelectList(await _db.Hizmetler.ToListAsync(), "Id", "Ad", proje.HizmetId);
        return View(proje);
    }

    [HttpPost("duzenle/{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Duzenle(Proje proje)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Hizmetler = new SelectList(await _db.Hizmetler.ToListAsync(), "Id", "Ad", proje.HizmetId);
            return View(proje);
        }
        _db.Projeler.Update(proje);
        await _db.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    [HttpGet("sil/{id}")]
    public async Task<IActionResult> Sil(int id)
    {
        var proje = await _db.Projeler.Include(p => p.Hizmet).FirstOrDefaultAsync(p => p.Id == id);
        if (proje == null) return NotFound();
        return View(proje);
    }

    [HttpPost("sil/{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SilOnayla(int id)
    {
        var proje = await _db.Projeler.FindAsync(id);
        if (proje != null)
        {
            _db.Projeler.Remove(proje);
            await _db.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }
}
