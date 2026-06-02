using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KomürcüPeyzaj.Data;

namespace KomürcüPeyzaj.Controllers;

[Route("hakkimizda")]
public class HakkimizdaController : Controller
{
    private readonly AppDbContext _db;

    public HakkimizdaController(AppDbContext db) => _db = db;

    [HttpGet("")]
    public async Task<IActionResult> Index()
    {
        ViewBag.Ayarlar = await _db.SiteAyarlari.FirstOrDefaultAsync();
        ViewBag.Ekip = await _db.EkipUyeleri.OrderBy(e => e.Sira).ToListAsync();
        return View();
    }
}
