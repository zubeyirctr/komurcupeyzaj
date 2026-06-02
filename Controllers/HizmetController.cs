using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KomürcüPeyzaj.Data;

namespace KomürcüPeyzaj.Controllers;

[Route("hizmetler")]
public class HizmetController : Controller
{
    private readonly AppDbContext _db;
    public HizmetController(AppDbContext db) => _db = db;

    [HttpGet("")]
    public async Task<IActionResult> Index()
    {
        ViewBag.Hizmetler = await _db.Hizmetler.Where(h => h.AktifMi).OrderBy(h => h.Sira).ToListAsync();
        ViewBag.SSS = await _db.SSSMaddeleri.Where(s => s.AktifMi).OrderBy(s => s.Sira).ToListAsync();
        return View();
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Detay(int id)
    {
        var hizmet = await _db.Hizmetler.Include(h => h.Projeler).FirstOrDefaultAsync(h => h.Id == id);
        if (hizmet == null) return NotFound();
        return View(hizmet);
    }
}
