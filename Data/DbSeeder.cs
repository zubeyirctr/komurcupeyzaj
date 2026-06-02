using KomürcüPeyzaj.Models;

namespace KomürcüPeyzaj.Data;

public static class DbSeeder
{
    public static void Seed(IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        db.Database.EnsureCreated();

        if (db.Hizmetler.Any()) return;

        // ── Hizmetler ────────────────────────────────────────────────────────
        var hizmetler = new List<Hizmet>
        {
            new() { Ad = "Bahçe Tasarımı",   KisaAciklama = "Hayalinizdeki bahçeyi profesyonel eller tasarlıyor.", Aciklama = "Uzman peyzaj mimarlarımız alanınızın topoğrafyası, iklimi ve zevklerinizi göz önünde bulundurarak özgün bahçe tasarımları oluşturur. Çizimden uygulamaya her aşamada yanınızdayız.", Ikon = "bi-tree",             GorselUrl = "/images/hizmetler/bahce-tasarimi.jpg", AktifMi = true, Sira = 1 },
            new() { Ad = "Rulo Çim",          KisaAciklama = "Anında yeşillik, hızlı ve temiz uygulama.",           Aciklama = "Yüksek kaliteli rulo çim uygulamasıyla bahçenizi kısa sürede yeşile kavuşturuyoruz. Hazırlık, döşeme ve ilk bakım hizmetleri eksiksiz sunulur.",                                     Ikon = "bi-grid",            GorselUrl = "/images/hizmetler/rulo-cim.jpg",       AktifMi = true, Sira = 2 },
            new() { Ad = "Bahçe Bakımı",      KisaAciklama = "Düzenli bakım ve budama hizmetleri.",                  Aciklama = "Çim biçme, budama, gübreleme ve sulama takibiyle bahçeniz her zaman en iyi halinde kalır. Aylık veya mevsimlik bakım paketleri mevcuttur.",                                           Ikon = "bi-scissors",        GorselUrl = "/images/hizmetler/site-bakimi.jpg",    AktifMi = true, Sira = 3 },
            new() { Ad = "Oyun Grubu",        KisaAciklama = "Çocuklar için güvenli ve eğlenceli oyun alanları.",   Aciklama = "Çocuk güvenliği sertifikalı malzemelerle, bahçenize veya terasa uygun oyun grupları tasarlayıp kuruyoruz. Renk ve model seçenekleri geniştir.",                                     Ikon = "bi-emoji-smile",     GorselUrl = "/images/hizmetler/bahce-tasarimi.jpg", AktifMi = true, Sira = 4 },
            new() { Ad = "Oturma Grubu",      KisaAciklama = "Dış mekan oturma ve dinlenme alanları.",              Aciklama = "Ahşap, metal veya rattan seçenekleriyle dış mekan oturma düzenlemeleri yapıyoruz. Pergola, teras ve balkon çözümleri de sunulmaktadır.",                                            Ikon = "bi-sun",             GorselUrl = "/images/hizmetler/bahce-tasarimi.jpg", AktifMi = true, Sira = 5 },
            new() { Ad = "Sulama Sistemleri", KisaAciklama = "Otomatik sulama sistemi kurulum ve bakımı.",          Aciklama = "Damla sulama ve yağmurlama sistemleri kurarak bitkilerinizin ihtiyacı kadar su almasını sağlıyoruz. Akıllı kontrol sistemleriyle uzaktan yönetim imkânı sunuyoruz.",                  Ikon = "bi-droplet",         GorselUrl = "/images/hizmetler/sulama.jpg",         AktifMi = true, Sira = 6 },
            new() { Ad = "Danışmanlık",       KisaAciklama = "Uzman peyzaj danışmanlığı ve proje rehberliği.",      Aciklama = "Alanınızı nasıl değerlendireceğinizi bilmiyor musunuz? Uzman ekibimiz yerinde keşif yaparak size en uygun çözümü sunar. Bitkiden zemine kapsamlı danışmanlık.",                      Ikon = "bi-clipboard-check", GorselUrl = "/images/hizmetler/bahce-tasarimi.jpg", AktifMi = true, Sira = 7 },
            new() { Ad = "Site Bakımı",       KisaAciklama = "Toplu konut ve site bahçeleri için periyodik bakım.", Aciklama = "Rezidans, site ve apartman komplekslerinin ortak yeşil alanlarını düzenli ve profesyonel ekibimizle bakıma alıyoruz. Yıllık bakım sözleşmeleri mevcuttur.",                          Ikon = "bi-tools",           GorselUrl = "/images/hizmetler/site-bakimi.jpg",    AktifMi = true, Sira = 8 }
        };
        db.Hizmetler.AddRange(hizmetler);
        db.SaveChanges();

        // ── Ürünler ──────────────────────────────────────────────────────────
        db.Urunler.AddRange(
            new Urun { Ad = "Organik Bahçe Gübresi",    KisaAciklama = "Bitkilerinizi doğal yollarla besleyen organik gübre.",          Aciklama = "Tamamen doğal hammaddelerden üretilen organik bahçe gübresi, bitkilerinizin sağlıklı büyümesini destekler. Toprak yapısını iyileştirir, uzun süreli besin sağlar.",                              GorselUrl = "/images/hizmetler/bahce-tasarimi.jpg", Fiyat = 0, Kategori = "Bitki Besinleri ve Gübreler", AktifMi = true, StokVarMi = true, Sira = 1 },
            new Urun { Ad = "Çim Gübresi",              KisaAciklama = "Çim alanlarınız için özel formüle edilmiş gübre.",              Aciklama = "Yoğun azot ve demir içeriğiyle çim alanlarınıza koyu yeşil renk ve güçlü büyüme sağlar. Rulo çim ve tohumlu çim için uygundur.",                                                                  GorselUrl = "/images/hizmetler/bahce-tasarimi.jpg", Fiyat = 0, Kategori = "Bitki Besinleri ve Gübreler", AktifMi = true, StokVarMi = true, Sira = 2 },
            new Urun { Ad = "Çim Tohumu Karışımı",      KisaAciklama = "Hızlı tutunma ve dayanıklı çim için premium tohum.",           Aciklama = "Farklı çim türlerinin harmanlanmasıyla oluşturulan premium karışım. Serin ve sıcak iklimlere uyum sağlar, hızlı çimlenme garantisi sunar.",                                                         GorselUrl = "/images/hizmetler/bahce-tasarimi.jpg", Fiyat = 0, Kategori = "Tohum",                       AktifMi = true, StokVarMi = true, Sira = 3 },
            new Urun { Ad = "Çiçek Tohumu Seti",        KisaAciklama = "Renkli bir bahçe için 12 farklı çiçek tohumu.",                Aciklama = "Tek yıllık ve çok yıllık 12 farklı çiçek tohumundan oluşan set. Mevsim boyunca renk ve güzellik sunar. Yeni başlayanlar için idealdir.",                                                             GorselUrl = "/images/hizmetler/bahce-tasarimi.jpg", Fiyat = 0, Kategori = "Tohum",                       AktifMi = true, StokVarMi = true, Sira = 4 },
            new Urun { Ad = "Böcek İlacı",              KisaAciklama = "Bitkilerinizi zararlı böceklerden korur.",                     Aciklama = "Geniş spektrumlu böcek ilacı; yaprakbiti, kırmızı örümcek ve beyazsinek başta olmak üzere pek çok zararlıya karşı etkilidir. İnsan ve evcil hayvanlara karşı güvenli formül.",                    GorselUrl = "/images/urunler/zirai-ilac.jpg",       Fiyat = 0, Kategori = "Zirai İlaçlar",               AktifMi = true, StokVarMi = true, Sira = 5 },
            new Urun { Ad = "Mantar İlacı",             KisaAciklama = "Fungal hastalıklara karşı koruyucu ve tedavi edici.",          Aciklama = "Külleme, pas ve çeşitli fungal hastalıklara karşı önleyici ve tedavi edici etki gösterir. Sebze, meyve ve süs bitkilerinde kullanılabilir.",                                                         GorselUrl = "/images/urunler/zirai-ilac.jpg",       Fiyat = 0, Kategori = "Zirai İlaçlar",               AktifMi = true, StokVarMi = true, Sira = 6 },
            new Urun { Ad = "Profesyonel Budama Makası", KisaAciklama = "Uzun ömürlü, ergonomik profesyonel budama makası.",           Aciklama = "Paslanmaz çelik bıçak ve ergonomik tutamağıyla uzun süreli kullanımda bile yorgunluk hissettirmeyen profesyonel budama makası. 3 cm çapına kadar dal kesebilir.",                                   GorselUrl = "/images/urunler/budama-makasi.jpg",    Fiyat = 0, Kategori = "Bahçe Ekipmanları",           AktifMi = true, StokVarMi = true, Sira = 7 },
            new Urun { Ad = "Bahçe Eldiveni Seti",      KisaAciklama = "3'lü bahçe eldiveni seti; farklı işler için.",                Aciklama = "İnce işler, dikenli bitkiler ve ağır işler için 3 farklı kalınlıkta eldiven içerir. Su geçirmez ve nefes alabilir malzeme, tüm mevsim kullanıma uygun.",                                              GorselUrl = "/images/urunler/bahce-eldiven.jpg",    Fiyat = 0, Kategori = "Bahçe Ekipmanları",           AktifMi = true, StokVarMi = true, Sira = 8 },
            new Urun { Ad = "Premium Torf",             KisaAciklama = "Yüksek organik madde içerikli premium torf.",                  Aciklama = "Sphagnum yosunundan elde edilen premium torf; su tutma kapasitesi yüksek, hafif ve hava geçirgen yapısıyla saksı ve bahçe topraklarına karıştırılabilir.",                                             GorselUrl = "/images/hizmetler/bahce-tasarimi.jpg", Fiyat = 0, Kategori = "Torf & Bahçe Toprakları",     AktifMi = true, StokVarMi = true, Sira = 9 },
            new Urun { Ad = "Çiçek Toprağı",           KisaAciklama = "Saksı ve balkon çiçekleri için hazır besleyici toprak.",       Aciklama = "Saksı, balkon ve teras bitkiler için özel hazırlanmış besleyici toprak. Perlit, torf ve kompost karışımıyla ideal drenaj ve besin dengesi sağlar.",                                                 GorselUrl = "/images/hizmetler/bahce-tasarimi.jpg", Fiyat = 0, Kategori = "Torf & Bahçe Toprakları",     AktifMi = true, StokVarMi = true, Sira = 10 },
            new Urun { Ad = "Standart Rulo Çim (m²)",   KisaAciklama = "Ekonomik ve hızlı tutunan standart rulo çim.",                Aciklama = "Dayanıklı ve kolay bakımlı standart rulo çim, bahçenizi kısa sürede yeşile kavuşturur. Fiyat m² bazındadır; montaj hizmeti ayrıca sunulmaktadır.",                                                     GorselUrl = "/images/hizmetler/rulo-cim.jpg",       Fiyat = 0, Kategori = "Rulo Çim",                     AktifMi = true, StokVarMi = true, Sira = 11 },
            new Urun { Ad = "Premium Rulo Çim (m²)",    KisaAciklama = "Yoğun ve kadifemsi görünüm sunan premium çim.",               Aciklama = "Koyu yeşil rengi ve yoğun dokusuyla villa, rezidans ve özel alanlara özel premium rulo çim. Kurağa ve yoğun kullanıma dayanıklıdır. Fiyat m² bazındadır.",                                             GorselUrl = "/images/hizmetler/rulo-cim.jpg",       Fiyat = 0, Kategori = "Rulo Çim",                     AktifMi = true, StokVarMi = true, Sira = 12 }
        );
        db.SaveChanges();

        // ── Projeler ─────────────────────────────────────────────────────────
        var projeler = new List<Proje>
        {
            new() { Ad = "Yıldız Villa Bahçesi",   Aciklama = "1500 m² alana sahip villa bahçesinin komple peyzaj tasarımı ve uygulaması. Mediteran tarzı bitkisel donatılar, otomatik sulama ve dekoratif aydınlatmayla tamamlandı.", Konum = "Beykoz, İstanbul",       TamamlanmaTarihi = new DateTime(2024, 8, 15),  KapakGorsel = "/images/projeler/villa-peyzaj.jpg",    OncesiGorsel = "/images/projeler/oncesi-sonrasi.jpg", SonrasiGorsel = "/images/projeler/villa-peyzaj.jpg", Kategori = "Villa",  OneIkartilsinMi = true,  HizmetId = 1 },
            new() { Ad = "Panorama Teras",          Aciklama = "Boğaz manzaralı penthouse terasının modern peyzaj tasarımı. Saksı bitkileri, ahşap deck ve dış mekân oturma alanı oluşturuldu.",                                        Konum = "Üsküdar, İstanbul",      TamamlanmaTarihi = new DateTime(2024, 6, 20),  KapakGorsel = "/images/projeler/teras.jpg",            OncesiGorsel = "/images/projeler/oncesi-sonrasi.jpg", SonrasiGorsel = "/images/projeler/villa-peyzaj.jpg", Kategori = "Teras",  OneIkartilsinMi = true,  HizmetId = 5 },
            new() { Ad = "Yeşilköy Mahalle Parkı", Aciklama = "Belediye ortaklığıyla gerçekleştirilen 3000 m² mahalle parkı peyzaj projesi. Çocuk oyun alanı, yürüyüş yolları ve piknik alanları oluşturuldu.",                        Konum = "Bakırköy, İstanbul",     TamamlanmaTarihi = new DateTime(2024, 4, 10),  KapakGorsel = "/images/projeler/mahalle-parki.jpg",   OncesiGorsel = "/images/projeler/oncesi-sonrasi.jpg", SonrasiGorsel = "/images/projeler/villa-peyzaj.jpg", Kategori = "Park",   OneIkartilsinMi = true,  HizmetId = 1 },
            new() { Ad = "Çatı Bahçesi Dönüşümü",  Aciklama = "200 m² çatı katının yeşil terasa dönüştürülmesi. Hafif substrat, yağmur suyu toplama sistemi ve dayanıklı bitkilerle tamamlandı.",                                       Konum = "Şişli, İstanbul",        TamamlanmaTarihi = new DateTime(2024, 3, 5),   KapakGorsel = "/images/projeler/teras.jpg",            OncesiGorsel = "/images/projeler/oncesi-sonrasi.jpg", SonrasiGorsel = "/images/projeler/villa-peyzaj.jpg", Kategori = "Teras",  OneIkartilsinMi = false, HizmetId = 1 },
            new() { Ad = "Havuzlu Villa Bahçesi",  Aciklama = "Infinity havuz ve çevre peyzajın birlikte tasarlandığı prestijli villa projesi. Tropikal bitki seçimleri ve gece aydınlatmasıyla Akdeniz havası yaratıldı.",               Konum = "Bodrum, Muğla",          TamamlanmaTarihi = new DateTime(2023, 9, 30),  KapakGorsel = "/images/projeler/villa-peyzaj.jpg",    OncesiGorsel = "/images/projeler/oncesi-sonrasi.jpg", SonrasiGorsel = "/images/projeler/villa-peyzaj.jpg", Kategori = "Villa",  OneIkartilsinMi = false, HizmetId = 1 },
            new() { Ad = "Kurumsal Ofis Bahçesi",  Aciklama = "Tech firmasının kampüsü için 800 m² ofis bahçesi. Çalışanların dinlenebileceği yeşil alanlar, açık hava toplantı köşeleri ve yemek bahçesi oluşturuldu.",                 Konum = "Maslak, İstanbul",       TamamlanmaTarihi = new DateTime(2023, 7, 22),  KapakGorsel = "/images/hizmetler/bahce-tasarimi.jpg", OncesiGorsel = "/images/projeler/oncesi-sonrasi.jpg", SonrasiGorsel = "/images/projeler/villa-peyzaj.jpg", Kategori = "Bahçe",  OneIkartilsinMi = false, HizmetId = 1 },
            new() { Ad = "Rezidans Teras Projesi", Aciklama = "Rezidans kompleksinin ortak teras alanının peyzaj ve mobilya düzenlemesi. Oturma zonları, bitki saksıları ve sezonluk çiçek ekimiyle tamamlandı.",                         Konum = "Levent, İstanbul",       TamamlanmaTarihi = new DateTime(2023, 5, 18),  KapakGorsel = "/images/projeler/teras.jpg",            OncesiGorsel = "/images/projeler/oncesi-sonrasi.jpg", SonrasiGorsel = "/images/projeler/villa-peyzaj.jpg", Kategori = "Teras",  OneIkartilsinMi = false, HizmetId = 5 },
            new() { Ad = "Site Peyzaj Projesi",    Aciklama = "Büyük bir konut sitesinin tüm peyzaj bakım ve düzenleme işleri. Çim alanları, ağaçlandırma ve çiçek ekimiyle yaşam kalitesi yükseltildi.",                                Konum = "Küçükçekmece, İstanbul", TamamlanmaTarihi = new DateTime(2023, 11, 12), KapakGorsel = "/images/hizmetler/site-bakimi.jpg",    OncesiGorsel = "/images/projeler/oncesi-sonrasi.jpg", SonrasiGorsel = "/images/projeler/villa-peyzaj.jpg", Kategori = "Bahçe",  OneIkartilsinMi = false, HizmetId = 8 }
        };
        db.Projeler.AddRange(projeler);
        db.SaveChanges();

        // Proje görselleri
        db.ProjeGorseller.AddRange(
            new ProjeGorsel { ProjeId = 1, GorselUrl = "/images/projeler/villa-peyzaj.jpg",    Baslik = "Genel" },
            new ProjeGorsel { ProjeId = 1, GorselUrl = "/images/hizmetler/bahce-tasarimi.jpg", Baslik = "Detay" },
            new ProjeGorsel { ProjeId = 1, GorselUrl = "/images/projeler/oncesi-sonrasi.jpg",  Baslik = "Öncesi/Sonrası" },
            new ProjeGorsel { ProjeId = 2, GorselUrl = "/images/projeler/teras.jpg",           Baslik = "Teras" },
            new ProjeGorsel { ProjeId = 2, GorselUrl = "/images/projeler/oncesi-sonrasi.jpg",  Baslik = "Öncesi/Sonrası" },
            new ProjeGorsel { ProjeId = 3, GorselUrl = "/images/projeler/mahalle-parki.jpg",   Baslik = "Park" }
        );
        db.SaveChanges();

        // ── Referanslar ──────────────────────────────────────────────────────
        db.Referanslar.AddRange(
            new Referans { AdSoyad = "Meral Özcan",     Unvan = "Villa Sahibi",         Sehir = "İstanbul", Yorum = "Bahçemizi hayal ettiğimizden çok daha güzel hale getirdiler. Ekip son derece profesyonel ve özenli çalıştı. Her detayı düşünmüşler.",           ProjeAdi = "Villa Bahçesi",      Puan = 5, FotoUrl = "https://images.unsplash.com/photo-1494790108377-be9c29b29330?w=200", YayindaMi = true, Tarih = new DateTime(2024, 9, 10) },
            new Referans { AdSoyad = "Kadir Şahin",     Unvan = "İşletme Müdürü",       Sehir = "Ankara",   Yorum = "Ofis bahçemizi beklentilerimizin üzerinde bir çalışmayla teslim ettiler. Çalışanlarımız artık çok daha mutlu. Kesinlikle tavsiye ederim.",     ProjeAdi = "Ofis Bahçesi",       Puan = 5, FotoUrl = "https://images.unsplash.com/photo-1507003211169-0a1dd7228f2d?w=200", YayindaMi = true, Tarih = new DateTime(2024, 7, 22) },
            new Referans { AdSoyad = "Selin Arslan",    Unvan = "Ev Sahibi",             Sehir = "İzmir",    Yorum = "Küçük balkonumu cennete çevirdiler. Hem estetik hem işlevsel bir sonuç çıktı. Fiyat/performans açısından mükemmel.",                             ProjeAdi = "Balkon Düzenlemesi", Puan = 5, FotoUrl = "https://images.unsplash.com/photo-1438761681033-6461ffad8d80?w=200", YayindaMi = true, Tarih = new DateTime(2024, 5, 15) },
            new Referans { AdSoyad = "Hüseyin Doğan",   Unvan = "Çiftlik Sahibi",       Sehir = "Bursa",    Yorum = "Geniş arazimizin peyzaj planlamasını büyük bir titizlikle yaptılar. Uzun vadeli bakım planı da hazırladılar. Çok memnunuz.",                     ProjeAdi = "Arazi Peyzajı",      Puan = 5, FotoUrl = "https://images.unsplash.com/photo-1472099645785-5658abf4ff4e?w=200", YayindaMi = true, Tarih = new DateTime(2024, 3, 8) },
            new Referans { AdSoyad = "Ayşe Kaya",       Unvan = "Apartman Yöneticisi",  Sehir = "İstanbul", Yorum = "Site bahçemizin tamamen yenilenmesini istedik. Sonuç muhteşem, sakinlerimizden sadece güzel yorumlar alıyoruz.",                                 ProjeAdi = "Site Bahçesi",       Puan = 5, FotoUrl = "https://images.unsplash.com/photo-1544005313-94ddf0286df2?w=200",  YayindaMi = true, Tarih = new DateTime(2024, 1, 20) },
            new Referans { AdSoyad = "Emre Yılmaz",     Unvan = "Restoran Sahibi",       Sehir = "Antalya",  Yorum = "Restoranımızın dış mekânını harika bir oturma alanına dönüştürdüler. Müşterilerimiz artık dışarıda oturmayı tercih ediyor.",                    ProjeAdi = "Restoran Terası",    Puan = 5, FotoUrl = "https://images.unsplash.com/photo-1500648767791-00dcc994a43e?w=200", YayindaMi = true, Tarih = new DateTime(2023, 11, 5) },
            new Referans { AdSoyad = "Çorum FK",         Unvan = "Futbol Kulübü",        Sehir = "Çorum",    Yorum = "Kömürcü Peyzaj ile tohum tedariğimizden profesyonel ve kaliteli bir hizmet aldık.",                                                              Puan = 5, FirmaAdi = "Saray Çorum FK",    KurumsalMi = true, YayindaMi = true, Tarih = new DateTime(2024, 10, 1) },
            new Referans { AdSoyad = "Atakon Grup",      Unvan = "İnşaat & Gayrimenkul", Sehir = "Çorum",    Yorum = "Projelerimizde peyzaj işlerini Kömürcü Peyzaj ile yürütüyoruz. Her zaman zamanında ve kaliteli teslim.",                                         Puan = 5, FirmaAdi = "Atakon Grup",       KurumsalMi = true, YayindaMi = true, Tarih = new DateTime(2024, 9, 15) },
            new Referans { AdSoyad = "Temsa Pilavcı Oto", Unvan = "Otomotiv",            Sehir = "İstanbul", Yorum = "Showroom bahçe düzenlememizi Kömürcü Peyzaj yaptı. Müşterilerimizden çok olumlu geri dönüşler alıyoruz.",                                       Puan = 5, FirmaAdi = "Temsa Pilavcı Oto", KurumsalMi = true, YayindaMi = true, Tarih = new DateTime(2024, 8, 20) }
        );
        db.SaveChanges();

        // ── Blog yazıları ────────────────────────────────────────────────────
        db.BlogYazilari.AddRange(
            new BlogYazisi { Baslik = "Bahçenizi İlkbahara Hazırlamak İçin 10 İpucu", KisaAciklama = "Kış uykusundan çıkan bahçenizi canlı tutmak için uzman önerilerimiz.", Icerik = "<p>İlkbahar, bahçe sahipleri için en heyecan verici mevsimdir. Bu rehberde bahçenizi yeni sezona hazırlamak için yapmanız gerekenleri adım adım anlatıyoruz.</p><h3>1. Toprak Hazırlığı</h3><p>Toprağınızı 15-20 cm derinliğe kadar gevşetin. Olgunlaşmış kompost veya yanmış çiftlik gübresi ekleyin.</p><h3>2. Budama Zamanı</h3><p>Kıştan kalan kuru ve hasarlı dalları temizleyin. Gül ve çiçekli çalılar için ideal dönem şimdidir.</p>", KapakGorsel = "/images/blog/blog1.jpeg", YayinTarihi = new DateTime(2025, 3, 15), Etiketler = "bahçe,ilkbahar,bakım",   YayindaMi = true, OkunmaSayisi = 142 },
            new BlogYazisi { Baslik = "Doğru Sulama Sistemi Nasıl Seçilir?",           KisaAciklama = "Bahçenizin büyüklüğüne göre en uygun sulama sistemini öğrenin.",       Icerik = "<p>Sulama sistemi seçimi, bahçe bakımının en önemli kararlarından biridir. Yanlış sistem seçimi su israfına neden olabilir.</p><h3>Damla Sulama</h3><p>Sebze ve meyve bahçeleri için idealdir. Su tasarrufu yüzde 30-50 oranında artar.</p>",                                                                                                                                                                                         KapakGorsel = "/images/blog/blog2.jpeg", YayinTarihi = new DateTime(2025, 2, 8),  Etiketler = "sulama,sistem,tasarruf", YayindaMi = true, OkunmaSayisi = 98 },
            new BlogYazisi { Baslik = "Peyzaj Tasarımında 2025 Trendleri",             KisaAciklama = "Bu yıl öne çıkan peyzaj trendlerini ve doğa dostu yaklaşımları keşfedin.", Icerik = "<p>Peyzaj tasarımı her yıl yeni trendlerle şekilleniyor. 2025 yılı sürdürülebilirlik ve doğallığın öne çıktığı bir dönem.</p><h3>Doğal Görünümlü Bahçeler</h3><p>Geometrik tasarımların yerini serbest, doğal görünümlü bahçeler alıyor.</p>",                                                                                                                                                                                              KapakGorsel = "/images/blog/blog1.jpeg", YayinTarihi = new DateTime(2025, 4, 5),  Etiketler = "trend,2025,peyzaj",     YayindaMi = true, OkunmaSayisi = 176 }
        );
        db.SaveChanges();

        // ── SSS ──────────────────────────────────────────────────────────────
        db.SSSMaddeleri.AddRange(
            new SSSMadde { Soru = "Hizmet bölgeniz neresi?",          Cevap = "İstanbul ve çevre illerde hizmet vermekteyiz. Küçükçekmece merkezli olarak tüm İstanbul'a ulaşıyoruz.",                                                                              Sira = 1 },
            new SSSMadde { Soru = "Fiyatlarınız nasıl belirleniyor?", Cevap = "Fiyatlarımız projenin büyüklüğüne, kullanılacak malzemeye ve iş gücüne göre belirlenmektedir. Ücretsiz keşif sonrası size özel fiyat sunuyoruz.",                                    Sira = 2 },
            new SSSMadde { Soru = "Çalışma süreniz ne kadar?",         Cevap = "Projenin kapsamına göre değişmekle birlikte küçük bahçeler 1-3 gün, büyük projeler 1-4 hafta arasında tamamlanmaktadır.",                                                           Sira = 3 },
            new SSSMadde { Soru = "Garanti veriyor musunuz?",          Cevap = "Evet, tüm işçilik ve malzeme için 1 yıl garanti veriyoruz. Rulo çim için 6 ay bakım desteği sağlıyoruz.",                                                                            Sira = 4 },
            new SSSMadde { Soru = "Ödeme seçenekleri neler?",          Cevap = "Nakit, kredi kartı ve banka havalesi ile ödeme kabul ediyoruz. Büyük projelerde taksit imkânı da sunulmaktadır.",                                                                    Sira = 5 },
            new SSSMadde { Soru = "Keşif ücretsiz mi?",                Cevap = "Evet, ilk keşif ve fiyat teklifi tamamen ücretsizdir. 0530 096 70 91 numaralı hattımızı arayabilirsiniz.",                                                                           Sira = 6 }
        );
        db.SaveChanges();

        // ── Ekip ─────────────────────────────────────────────────────────────
        db.EkipUyeleri.AddRange(
            new EkipUyesi { AdSoyad = "Ahmet Kömürcü", Unvan = "Kurucu & Baş Peyzaj Mimarı", Biyografi = "15 yıllık peyzaj tasarımı deneyimiyle Kömürcü Peyzaj'ı kurdu. Yüzlerce başarılı proje imzası var.",             FotoUrl = "https://images.unsplash.com/photo-1507003211169-0a1dd7228f2d?w=400", Sira = 1 },
            new EkipUyesi { AdSoyad = "Zeynep Yıldız", Unvan = "Kıdemli Tasarımcı",          Biyografi = "İTÜ Peyzaj Mimarlığı mezunu. Kentsel yeşil alan ve çatı bahçeleri konusunda uzman.",                            FotoUrl = "https://images.unsplash.com/photo-1494790108377-be9c29b29330?w=400", Sira = 2 },
            new EkipUyesi { AdSoyad = "Murat Demir",   Unvan = "Sulama Sistemleri Uzmanı",   Biyografi = "10 yıllık saha deneyimiyle akıllı sulama sistemleri kurulumu konusunda sertifikalı uzman.",                     FotoUrl = "https://images.unsplash.com/photo-1472099645785-5658abf4ff4e?w=400", Sira = 3 }
        );
        db.SaveChanges();

        // ── Site ayarları ─────────────────────────────────────────────────────
        db.SiteAyarlari.Add(new SiteAyarlari
        {
            FirmaAdi        = "Kömürcü Peyzaj",
            Slogan          = "Manzara Katıyoruz",
            Telefon         = "0530 096 70 91",
            Email           = "— Yakında —",
            Adres           = "Kömürcü Yolu Caddesi, Halkalı, Küçükçekmece / İstanbul",
            GoogleMapsEmbed = "<iframe src=\"https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3010.5!2d28.7798!3d41.0082!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x14caa4a0a9fd0df5%3A0x4e11e2df3af7c9c7!2sHalkal%C4%B1%2C%20K%C3%BC%C3%A7%C3%BCk%C3%A7ekmece%2F%C4%B0stanbul!5e0!3m2!1str!2str\" width=\"100%\" height=\"350\" style=\"border:0;\" allowfullscreen loading=\"lazy\"></iframe>",
            WhatsApp        = "https://wa.me/905300967091",
            Instagram       = "#",
            TikTok          = "#",
            TamamlananProje = 0,
            MutluMusteri    = 0,
            DeneyimYili     = 0
        });
        db.SaveChanges();
    }
}
