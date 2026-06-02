# 🌿 Kömürcü Peyzaj Web Sitesi

## 🌐 Demo
https://komurcupeyzaj-production.up.railway.app

Kömürcü Peyzaj firması için geliştirilmiş profesyonel kurumsal web sitesi.

📌 Tanıtım
Kömürcü Peyzaj firması için geliştirilmiş profesyonel kurumsal web sitesi. 
Firma hizmetlerini, tamamlanan projelerini, ürünlerini ve referanslarını dijital ortamda sergiler. 
Admin paneli üzerinden tüm içerikler yönetilebilir.

⚙️ Teknik Özellikler
KatmanTeknolojiBackendASP.NET Core MVC (.NET 8)VeritabanıSQLite 
+ Entity Framework Core (Code First)FrontendBootstrap 5 
+ Vanilla JavaScriptTemplateRazor View Engine (.cshtml)DilC# 12
Kullanılan yapılar: CRUD işlemleri, LINQ sorguları, Navigation Property, Foreign Key ilişkileri, Form Validation, ViewBag, Code First Migration, DOM Manipülasyonu, Bootstrap bileşenleri


📁 Proje Yapısı
KomürcüPeyzaj/
├── Controllers/        → Sayfa controller'ları + Admin CRUD
├── Models/             → Veritabanı modelleri (11 model)
├── Views/              → Razor sayfaları
├── Data/               → AppDbContext + DbSeeder
├── Migrations/         → EF Core migration dosyaları
├── wwwroot/            → CSS, JS, görseller
└── Program.cs          → Uygulama başlangıç noktası

🗄️ Veritabanı
11 model, SQLite ile saklanır. Temel ilişkiler:

Hizmet → Proje (One-to-Many)
Proje → ProjeGorsel (One-to-Many)

Diğer modeller bağımsız: Urun, Referans, BlogYazisi, IletisimMesaji, Abonelik, SSSMadde, EkipUyesi, SiteAyarlari

## Teknolojiler
- ASP.NET Core MVC (.NET 8)
- Entity Framework Core + SQLite
- Bootstrap 5
- JavaScript (Vanilla)

## Sayfalar
- Anasayfa, Hizmetler, Ürünler, Projeler, Referanslar, Blog, Hakkımızda, İletişim
- Admin Paneli (/admin)

🚀 Kurulum
bash# 1. Repoyu klonla
git clone https://github.com/zubeyirctr/komurcupeyzaj.git
cd komurcupeyzaj

# 2. Bağımlılıkları yükle
dotnet restore

# 3. Veritabanını oluştur (seed data otomatik yüklenir)
dotnet ef database update

# 4. Çalıştır
dotnet run
Tarayıcıda aç → https://localhost:5001
Admin paneli → https://localhost:5001/admin
