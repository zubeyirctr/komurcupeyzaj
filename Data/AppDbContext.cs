using Microsoft.EntityFrameworkCore;
using KomürcüPeyzaj.Models;

namespace KomürcüPeyzaj.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Urun> Urunler { get; set; }
    public DbSet<Hizmet> Hizmetler { get; set; }
    public DbSet<Proje> Projeler { get; set; }
    public DbSet<ProjeGorsel> ProjeGorseller { get; set; }
    public DbSet<Referans> Referanslar { get; set; }
    public DbSet<BlogYazisi> BlogYazilari { get; set; }
    public DbSet<IletisimMesaji> IletisimMesajlari { get; set; }
    public DbSet<Abonelik> Abonelikler { get; set; }
    public DbSet<SSSMadde> SSSMaddeleri { get; set; }
    public DbSet<EkipUyesi> EkipUyeleri { get; set; }
    public DbSet<SiteAyarlari> SiteAyarlari { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Proje>()
            .HasOne(p => p.Hizmet)
            .WithMany(h => h.Projeler)
            .HasForeignKey(p => p.HizmetId);

        modelBuilder.Entity<ProjeGorsel>()
            .HasOne(g => g.Proje)
            .WithMany(p => p.Gorseller)
            .HasForeignKey(g => g.ProjeId);
    }
}
