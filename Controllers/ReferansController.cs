using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KomürcüPeyzaj.Data;
using KomürcüPeyzaj.Models;

namespace KomürcüPeyzaj.Controllers;

[Route("referanslar")]
public class ReferansController : Controller
{
    private readonly AppDbContext _db;
    public ReferansController(AppDbContext db) => _db = db;

    [HttpGet("")]
    public async Task<IActionResult> Index()
    {
        var tumReferanslar = await _db.Referanslar.Where(r => r.YayindaMi).OrderByDescending(r => r.Tarih).ToListAsync();
        ViewBag.KurumsalReferanslar = tumReferanslar.Where(r => r.KurumsalMi).ToList();
        ViewBag.Referanslar = tumReferanslar.Where(r => !r.KurumsalMi).ToList();
        return View(new Referans());
    }

    [HttpPost("")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Index(Referans yeniReferans)
    {
        if (!ModelState.IsValid)
        {
            var tumReferanslar = await _db.Referanslar.Where(r => r.YayindaMi).OrderByDescending(r => r.Tarih).ToListAsync();
            ViewBag.KurumsalReferanslar = tumReferanslar.Where(r => r.KurumsalMi).ToList();
            ViewBag.Referanslar = tumReferanslar.Where(r => !r.KurumsalMi).ToList();
            return View(yeniReferans);
        }
        yeniReferans.YayindaMi = false;
        yeniReferans.Tarih = DateTime.Now;
        _db.Referanslar.Add(yeniReferans);
        await _db.SaveChangesAsync();
        TempData["Basari"] = "Yorumunuz alındı, onaylandıktan sonra yayınlanacaktır.";
        return RedirectToAction(nameof(Index));
    }
}
