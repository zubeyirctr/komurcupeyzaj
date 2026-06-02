using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KomürcüPeyzaj.Data;

namespace KomürcüPeyzaj.Controllers.Admin;

[Route("admin/mesajlar")]
public class MesajAdminController : Controller
{
    private readonly AppDbContext _db;

    public MesajAdminController(AppDbContext db) => _db = db;

    [HttpGet("")]
    public async Task<IActionResult> Index()
    {
        var mesajlar = await _db.IletisimMesajlari
            .OrderBy(m => m.OkunduMu)
            .ThenByDescending(m => m.GonderimTarihi)
            .ToListAsync();
        return View(mesajlar);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Detay(int id)
    {
        var mesaj = await _db.IletisimMesajlari.FindAsync(id);
        if (mesaj == null) return NotFound();

        mesaj.OkunduMu = true;
        await _db.SaveChangesAsync();

        return View(mesaj);
    }

    [HttpPost("sil/{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Sil(int id)
    {
        var mesaj = await _db.IletisimMesajlari.FindAsync(id);
        if (mesaj != null)
        {
            _db.IletisimMesajlari.Remove(mesaj);
            await _db.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }
}
