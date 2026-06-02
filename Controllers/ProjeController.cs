using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KomürcüPeyzaj.Data;

namespace KomürcüPeyzaj.Controllers;

[Route("projeler")]
public class ProjeController : Controller
{
    private readonly AppDbContext _db;
    public ProjeController(AppDbContext db) => _db = db;

    [HttpGet("")]
    public async Task<IActionResult> Index(string? kategori)
    {
        var query = _db.Projeler.Include(p => p.Hizmet).AsQueryable();
        if (!string.IsNullOrEmpty(kategori))
            query = query.Where(p => p.Kategori == kategori);

        ViewBag.Kategoriler = await _db.Projeler.Select(p => p.Kategori).Distinct().ToListAsync();
        ViewBag.SecilenKategori = kategori;
        ViewBag.OneProjeler = await _db.Projeler.Where(p => p.OneIkartilsinMi).Include(p => p.Hizmet).ToListAsync();
        return View(await query.ToListAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Detay(int id)
    {
        var proje = await _db.Projeler.Include(p => p.Gorseller).Include(p => p.Hizmet).FirstOrDefaultAsync(p => p.Id == id);
        if (proje == null) return NotFound();
        return View(proje);
    }
}
