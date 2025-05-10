# SimpleDoctor - Doktor Randevu Sistemi

Bu proje, ASP.NET Core MVC kullanılarak geliştirilmiş bir doktor randevu sistemidir.

## Proje Yapısı

### 1. API (REST API)
- **Konum**: `Controllers/Api/DoctorApiController.cs`
- **Endpoint'ler**:
  - `GET /api/doctor` - Tüm doktorları listeler
  - `GET /api/doctor/{id}` - Belirli bir doktoru getirir
  - `POST /api/doctor` - Yeni doktor ekler
  - `PUT /api/doctor/{id}` - Doktor bilgilerini günceller
  - `DELETE /api/doctor/{id}` - Doktor siler
- **Swagger Entegrasyonu**: Program.cs'de yapılandırılmış

### 2. Entity Framework
- **Konum**: `Data/ApplicationDbContext.cs`
- **Veritabanı**: SQL Server
- **Modeller**:
  - `Doctor` (Doktorlar)
  - `Appointment` (Randevular)
- **Migration'lar**: `Migrations` klasöründe
- **Versiyon**: Entity Framework Core 8.0.0

### 3. MVC (Model-View-Controller)
- **Controllers**:
  - `HomeController.cs` - Ana sayfa ve hata sayfaları
  - `DoctorController.cs` - Doktor işlemleri
- **Views**:
  - `Views/Doctor/` - Doktor sayfaları
  - `Views/Home/` - Ana sayfa
  - `Views/Shared/` - Paylaşılan layout ve partial view'lar
- **Models**:
  - `Doctor.cs` - Doktor modeli
  - `Appointment.cs` - Randevu modeli

### 4. Middleware
- **Konum**: `Middleware/RequestLoggingMiddleware.cs`
- **Yapılandırılmış Middleware'ler** (Program.cs'de):
  - `app.UseHttpsRedirection()` - HTTPS yönlendirmesi
  - `app.UseStaticFiles()` - Statik dosyalar
  - `app.UseRequestLogging()` - Özel loglama middleware'i
  - `app.UseRouting()` - Routing
  - `app.UseAuthorization()` - Yetkilendirme
  - `app.UseSwagger()` - Swagger UI (geliştirme ortamında)
  - `app.UseDeveloperExceptionPage()` - Geliştirici hata sayfası (geliştirme ortamında)

## Doktor Modeli Özellikleri
- Ad Soyad
- Uzmanlık Alanı
- Yan Dal
- Mezun Olduğu Okul
- Mezuniyet Yılı
- Özgeçmiş
- E-posta
- Telefon
- Çalışma Saatleri

## Randevu Modeli Özellikleri
- Hasta Adı
- Hasta E-posta
- Randevu Tarihi
- Doktor İlişkisi

## Teknolojiler
- ASP.NET Core 8.0
- Entity Framework Core 8.0
- SQL Server
- Bootstrap 5
- Font Awesome
- jQuery

## Geliştirme Ortamı Gereksinimleri
- .NET 8.0 SDK
- Visual Studio 2022 veya Visual Studio Code
- SQL Server (LocalDB veya tam sürüm)

## Kurulum
1. Projeyi klonlayın
2. Veritabanı bağlantı dizesini `appsettings.json` dosyasında yapılandırın
3. Package Manager Console'da şu komutları çalıştırın:
   ```
   dotnet restore
   dotnet ef database update
   ```
4. Uygulamayı başlatın:
   ```
   dotnet run
   ```

## API Dokümantasyonu
Swagger UI üzerinden API dokümantasyonuna erişebilirsiniz:
- Geliştirme ortamında: `https://localhost:5000/swagger`
- Üretim ortamında: `https://your-domain.com/swagger` 