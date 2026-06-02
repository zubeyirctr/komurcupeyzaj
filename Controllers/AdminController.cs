using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KomürcüPeyzaj.Data;
using KomürcüPeyzaj.Models;

namespace KomürcüPeyzaj.Controllers;

[Route("admin")]
public class AdminController : Controller
{
    private readonly AppDbContext _db;
    public AdminController(AppDbContext db) => _db = db;

    // ── Dashboard ────────────────────────────────────────────────────────────
    [HttpGet("")]
    public async Task<IActionResult> Index()
    {
        ViewBag.HizmetSayisi  = await _db.Hizmetler.CountAsync();
        ViewBag.UrunSayisi    = await _db.Urunler.CountAsync();
        ViewBag.ProjeSayisi   = await _db.Projeler.CountAsync();
        ViewBag.BlogSayisi    = await _db.BlogYazilari.CountAsync();
        ViewBag.ReferansSayisi = await _db.Referanslar.CountAsync(r => !r.YayindaMi);
        ViewBag.OkunmamisMesajSayisi = await _db.IletisimMesajlari.CountAsync(m => !m.OkunduMu);
        ViewBag.SonMesajlar   = await _db.IletisimMesajlari.OrderByDescending(m => m.GonderimTarihi).Take(5).ToListAsync();
        return View();
    }

    // ── Ürünler ──────────────────────────────────────────────────────────────
    [HttpGet("urunler")]
    public async Task<IActionResult> Urunler()
    {
        ViewData["Title"] = "Ürünler";
        return View("Urun/Index", await _db.Urunler.OrderBy(u => u.Kategori).ThenBy(u => u.Sira).ToListAsync());
    }

    [HttpGet("urunler/olustur")]
    public IActionResult UrunOlustur()
    {
        ViewData["Title"] = "Yeni Ürün";
        return View("Urun/Olustur", new Urun());
    }

    [HttpPost("urunler/olustur")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UrunOlustur(Urun urun)
    {
        if (!ModelState.IsValid) { ViewData["Title"] = "Yeni Ürün"; return View("Urun/Olustur", urun); }
        _db.Urunler.Add(urun);
        await _db.SaveChangesAsync();
        TempData["Basari"] = "Ürün oluşturuldu.";
        return RedirectToAction(nameof(Urunler));
    }

    [HttpGet("urunler/{id:int}/duzenle")]
    public async Task<IActionResult> UrunDuzenle(int id)
    {
        var u = await _db.Urunler.FindAsync(id);
        if (u == null) return NotFound();
        ViewData["Title"] = "Ürünü Düzenle";
        return View("Urun/Duzenle", u);
    }

    [HttpPost("urunler/{id:int}/duzenle")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UrunDuzenle(int id, Urun urun)
    {
        if (!ModelState.IsValid) { ViewData["Title"] = "Ürünü Düzenle"; return View("Urun/Duzenle", urun); }
        urun.Id = id;
        _db.Entry(urun).State = EntityState.Modified;
        await _db.SaveChangesAsync();
        TempData["Basari"] = "Ürün güncellendi.";
        return RedirectToAction(nameof(Urunler));
    }

    [HttpGet("urunler/{id:int}/sil")]
    public async Task<IActionResult> UrunSilOnay(int id)
    {
        var u = await _db.Urunler.FindAsync(id);
        if (u == null) return NotFound();
        ViewData["Title"] = "Ürünü Sil";
        return View("Urun/Sil", u);
    }

    [HttpPost("urunler/{id:int}/sil")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UrunSil(int id)
    {
        var u = await _db.Urunler.FindAsync(id);
        if (u != null) { _db.Urunler.Remove(u); await _db.SaveChangesAsync(); }
        TempData["Basari"] = "Ürün silindi.";
        return RedirectToAction(nameof(Urunler));
    }

    // ── Hizmetler ────────────────────────────────────────────────────────────
    [HttpGet("hizmetler")]
    public async Task<IActionResult> Hizmetler()
    {
        ViewData["Title"] = "Hizmetler";
        return View("Hizmet/Index", await _db.Hizmetler.OrderBy(h => h.Sira).ToListAsync());
    }

    [HttpGet("hizmetler/olustur")]
    public IActionResult HizmetOlustur()
    {
        ViewData["Title"] = "Yeni Hizmet";
        return View("Hizmet/Olustur", new Hizmet());
    }

    [HttpPost("hizmetler/olustur")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> HizmetOlustur(Hizmet hizmet)
    {
        if (!ModelState.IsValid) { ViewData["Title"] = "Yeni Hizmet"; return View("Hizmet/Olustur", hizmet); }
        _db.Hizmetler.Add(hizmet);
        await _db.SaveChangesAsync();
        TempData["Basari"] = "Hizmet oluşturuldu.";
        return RedirectToAction(nameof(Hizmetler));
    }

    [HttpGet("hizmetler/{id:int}/duzenle")]
    public async Task<IActionResult> HizmetDuzenle(int id)
    {
        var h = await _db.Hizmetler.FindAsync(id);
        if (h == null) return NotFound();
        ViewData["Title"] = "Hizmeti Düzenle";
        return View("Hizmet/Duzenle", h);
    }

    [HttpPost("hizmetler/{id:int}/duzenle")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> HizmetDuzenle(int id, Hizmet hizmet)
    {
        if (!ModelState.IsValid) { ViewData["Title"] = "Hizmeti Düzenle"; return View("Hizmet/Duzenle", hizmet); }
        hizmet.Id = id;
        _db.Entry(hizmet).State = EntityState.Modified;
        await _db.SaveChangesAsync();
        TempData["Basari"] = "Hizmet güncellendi.";
        return RedirectToAction(nameof(Hizmetler));
    }

    [HttpPost("hizmetler/{id:int}/sil")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> HizmetSil(int id)
    {
        var h = await _db.Hizmetler.FindAsync(id);
        if (h != null) { _db.Hizmetler.Remove(h); await _db.SaveChangesAsync(); }
        TempData["Basari"] = "Hizmet silindi.";
        return RedirectToAction(nameof(Hizmetler));
    }

    // ── Projeler ─────────────────────────────────────────────────────────────
    [HttpGet("projeler")]
    public async Task<IActionResult> Projeler()
    {
        ViewData["Title"] = "Projeler";
        return View("Proje/Index", await _db.Projeler.Include(p => p.Hizmet).OrderByDescending(p => p.TamamlanmaTarihi).ToListAsync());
    }

    [HttpGet("projeler/olustur")]
    public async Task<IActionResult> ProjeOlustur()
    {
        ViewData["Title"] = "Yeni Proje";
        ViewBag.Hizmetler = await _db.Hizmetler.Where(h => h.AktifMi).ToListAsync();
        return View("Proje/Olustur", new Proje());
    }

    [HttpPost("projeler/olustur")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ProjeOlustur(Proje proje)
    {
        if (!ModelState.IsValid) { ViewData["Title"] = "Yeni Proje"; ViewBag.Hizmetler = await _db.Hizmetler.ToListAsync(); return View("Proje/Olustur", proje); }
        _db.Projeler.Add(proje);
        await _db.SaveChangesAsync();
        TempData["Basari"] = "Proje oluşturuldu.";
        return RedirectToAction(nameof(Projeler));
    }

    [HttpGet("projeler/{id:int}/duzenle")]
    public async Task<IActionResult> ProjeDuzenle(int id)
    {
        var p = await _db.Projeler.FindAsync(id);
        if (p == null) return NotFound();
        ViewData["Title"] = "Projeyi Düzenle";
        ViewBag.Hizmetler = await _db.Hizmetler.ToListAsync();
        return View("Proje/Duzenle", p);
    }

    [HttpPost("projeler/{id:int}/duzenle")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ProjeDuzenle(int id, Proje proje)
    {
        if (!ModelState.IsValid) { ViewData["Title"] = "Projeyi Düzenle"; ViewBag.Hizmetler = await _db.Hizmetler.ToListAsync(); return View("Proje/Duzenle", proje); }
        proje.Id = id;
        _db.Entry(proje).State = EntityState.Modified;
        await _db.SaveChangesAsync();
        TempData["Basari"] = "Proje güncellendi.";
        return RedirectToAction(nameof(Projeler));
    }

    [HttpPost("projeler/{id:int}/sil")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ProjeSil(int id)
    {
        var p = await _db.Projeler.FindAsync(id);
        if (p != null) { _db.Projeler.Remove(p); await _db.SaveChangesAsync(); }
        TempData["Basari"] = "Proje silindi.";
        return RedirectToAction(nameof(Projeler));
    }

    // ── Referanslar ──────────────────────────────────────────────────────────
    [HttpGet("referanslar")]
    public async Task<IActionResult> Referanslar()
    {
        ViewData["Title"] = "Referanslar";
        return View("Referans/Index", await _db.Referanslar.OrderByDescending(r => r.Tarih).ToListAsync());
    }

    [HttpPost("referanslar/{id:int}/onayla")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ReferansOnayla(int id)
    {
        var r = await _db.Referanslar.FindAsync(id);
        if (r != null) { r.YayindaMi = true; await _db.SaveChangesAsync(); }
        TempData["Basari"] = "Referans onaylandı.";
        return RedirectToAction(nameof(Referanslar));
    }

    [HttpPost("referanslar/{id:int}/sil")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ReferansSil(int id)
    {
        var r = await _db.Referanslar.FindAsync(id);
        if (r != null) { _db.Referanslar.Remove(r); await _db.SaveChangesAsync(); }
        TempData["Basari"] = "Referans silindi.";
        return RedirectToAction(nameof(Referanslar));
    }

    // ── Blog ─────────────────────────────────────────────────────────────────
    [HttpGet("blog")]
    public async Task<IActionResult> Blog()
    {
        ViewData["Title"] = "Blog Yazıları";
        return View("Blog/Index", await _db.BlogYazilari.OrderByDescending(b => b.YayinTarihi).ToListAsync());
    }

    [HttpGet("blog/olustur")]
    public IActionResult BlogOlustur()
    {
        ViewData["Title"] = "Yeni Blog Yazısı";
        return View("Blog/Olustur", new BlogYazisi());
    }

    [HttpPost("blog/olustur")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> BlogOlustur(BlogYazisi yazi)
    {
        if (!ModelState.IsValid) { ViewData["Title"] = "Yeni Blog Yazısı"; return View("Blog/Olustur", yazi); }
        yazi.YayinTarihi = DateTime.Now;
        _db.BlogYazilari.Add(yazi);
        await _db.SaveChangesAsync();
        TempData["Basari"] = "Blog yazısı oluşturuldu.";
        return RedirectToAction(nameof(Blog));
    }

    [HttpGet("blog/{id:int}/duzenle")]
    public async Task<IActionResult> BlogDuzenle(int id)
    {
        var b = await _db.BlogYazilari.FindAsync(id);
        if (b == null) return NotFound();
        ViewData["Title"] = "Blog Yazısını Düzenle";
        return View("Blog/Duzenle", b);
    }

    [HttpPost("blog/{id:int}/duzenle")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> BlogDuzenle(int id, BlogYazisi yazi)
    {
        if (!ModelState.IsValid) { ViewData["Title"] = "Blog Yazısını Düzenle"; return View("Blog/Duzenle", yazi); }
        yazi.Id = id;
        _db.Entry(yazi).State = EntityState.Modified;
        await _db.SaveChangesAsync();
        TempData["Basari"] = "Blog yazısı güncellendi.";
        return RedirectToAction(nameof(Blog));
    }

    [HttpPost("blog/{id:int}/sil")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> BlogSil(int id)
    {
        var b = await _db.BlogYazilari.FindAsync(id);
        if (b != null) { _db.BlogYazilari.Remove(b); await _db.SaveChangesAsync(); }
        TempData["Basari"] = "Blog yazısı silindi.";
        return RedirectToAction(nameof(Blog));
    }

    // ── SSS ──────────────────────────────────────────────────────────────────
    [HttpGet("sss")]
    public async Task<IActionResult> SSS()
    {
        ViewData["Title"] = "SSS";
        return View("SSS/Index", await _db.SSSMaddeleri.OrderBy(s => s.Sira).ToListAsync());
    }

    [HttpGet("sss/olustur")]
    public IActionResult SssOlustur()
    {
        ViewData["Title"] = "Yeni SSS Maddesi";
        return View("SSS/Olustur", new SSSMadde());
    }

    [HttpPost("sss/olustur")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SssOlustur(SSSMadde madde)
    {
        if (!ModelState.IsValid) { ViewData["Title"] = "Yeni SSS Maddesi"; return View("SSS/Olustur", madde); }
        _db.SSSMaddeleri.Add(madde);
        await _db.SaveChangesAsync();
        TempData["Basari"] = "SSS maddesi oluşturuldu.";
        return RedirectToAction(nameof(SSS));
    }

    [HttpGet("sss/{id:int}/duzenle")]
    public async Task<IActionResult> SssDuzenle(int id)
    {
        var s = await _db.SSSMaddeleri.FindAsync(id);
        if (s == null) return NotFound();
        ViewData["Title"] = "SSS Düzenle";
        return View("SSS/Duzenle", s);
    }

    [HttpPost("sss/{id:int}/duzenle")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SssDuzenle(int id, SSSMadde madde)
    {
        if (!ModelState.IsValid) { ViewData["Title"] = "SSS Düzenle"; return View("SSS/Duzenle", madde); }
        madde.Id = id;
        _db.Entry(madde).State = EntityState.Modified;
        await _db.SaveChangesAsync();
        TempData["Basari"] = "SSS maddesi güncellendi.";
        return RedirectToAction(nameof(SSS));
    }

    [HttpPost("sss/{id:int}/sil")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SssSil(int id)
    {
        var s = await _db.SSSMaddeleri.FindAsync(id);
        if (s != null) { _db.SSSMaddeleri.Remove(s); await _db.SaveChangesAsync(); }
        TempData["Basari"] = "SSS maddesi silindi.";
        return RedirectToAction(nameof(SSS));
    }

    // ── Mesajlar ─────────────────────────────────────────────────────────────
    [HttpGet("mesajlar")]
    public async Task<IActionResult> Mesajlar()
    {
        ViewData["Title"] = "Mesajlar";
        return View("Mesaj/Index", await _db.IletisimMesajlari.OrderByDescending(m => m.GonderimTarihi).ToListAsync());
    }

    [HttpGet("mesajlar/{id:int}")]
    public async Task<IActionResult> MesajDetay(int id)
    {
        var m = await _db.IletisimMesajlari.FindAsync(id);
        if (m == null) return NotFound();
        if (!m.OkunduMu) { m.OkunduMu = true; await _db.SaveChangesAsync(); }
        ViewData["Title"] = "Mesaj Detayı";
        return View("Mesaj/Detay", m);
    }

    [HttpPost("mesajlar/{id:int}/sil")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> MesajSil(int id)
    {
        var m = await _db.IletisimMesajlari.FindAsync(id);
        if (m != null) { _db.IletisimMesajlari.Remove(m); await _db.SaveChangesAsync(); }
        TempData["Basari"] = "Mesaj silindi.";
        return RedirectToAction(nameof(Mesajlar));
    }

    // ── Ekip ─────────────────────────────────────────────────────────────────
    [HttpGet("ekip")]
    public async Task<IActionResult> Ekip()
    {
        ViewData["Title"] = "Ekip";
        return View("Ekip/Index", await _db.EkipUyeleri.OrderBy(e => e.Sira).ToListAsync());
    }

    // ── Ayarlar ──────────────────────────────────────────────────────────────
    [HttpGet("ayarlar")]
    public async Task<IActionResult> Ayarlar()
    {
        ViewData["Title"] = "Site Ayarları";
        var a = await _db.SiteAyarlari.FirstOrDefaultAsync() ?? new SiteAyarlari();
        return View("Ayarlar/Index", a);
    }

    [HttpPost("ayarlar")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Ayarlar(SiteAyarlari ayarlar)
    {
        if (!ModelState.IsValid) { ViewData["Title"] = "Site Ayarları"; return View("Ayarlar/Index", ayarlar); }
        var mevcut = await _db.SiteAyarlari.FirstOrDefaultAsync();
        if (mevcut == null) { _db.SiteAyarlari.Add(ayarlar); }
        else
        {
            ayarlar.Id = mevcut.Id;
            _db.Entry(mevcut).CurrentValues.SetValues(ayarlar);
        }
        await _db.SaveChangesAsync();
        TempData["Basari"] = "Ayarlar kaydedildi.";
        return RedirectToAction(nameof(Ayarlar));
    }
}
