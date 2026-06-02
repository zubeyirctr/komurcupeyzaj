using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KomürcüPeyzaj.Data;

namespace KomürcüPeyzaj.Controllers;

[Route("urunler")]
public class UrunController : Controller
{
    private readonly AppDbContext _db;
    public UrunController(AppDbContext db) => _db = db;

    [HttpGet("")]
    public async Task<IActionResult> Index()
    {
        ViewBag.Urunler = await _db.Urunler
            .Where(u => u.AktifMi)
            .OrderBy(u => u.Kategori)
            .ThenBy(u => u.Sira)
            .ToListAsync();
        return View();
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Detay(int id)
    {
        var urun = await _db.Urunler.FirstOrDefaultAsync(u => u.Id == id && u.AktifMi);
        if (urun == null) return NotFound();
        ViewBag.BenzerUrunler = await _db.Urunler
            .Where(u => u.Kategori == urun.Kategori && u.Id != id && u.AktifMi)
            .Take(4)
            .ToListAsync();
        return View(urun);
    }
}
