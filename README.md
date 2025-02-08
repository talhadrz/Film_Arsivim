# 🎬 Film Arşivim - Favorilerim  
Bu proje, kullanıcıların film arşivlerini yönetmelerine ve veritabanına film ekleyip silebilmelerine olanak tanır. Aynı zamanda YouTube bağlantılarıyla videoları oynatma, ileri-geri alma ve ses kontrolü gibi özellikler sunar.  

## 🚀 Özellikler  
- 🎥 **Film Listesi:** Veritabanındaki tüm filmleri tablo halinde görüntüler.  
- 🔗 **Film Ekleme & Silme:** Kullanıcılar film adı, kategori ve YouTube linki girerek film ekleyebilir ve silebilir.  
- 📺 **Video Oynatma:** Seçilen filmin YouTube linki tarayıcı içinde oynatılır.  
- ⏪ **İleri-Geri Alma:** Kayıtlı filmler arasında ileri ve geri geçiş yapma imkanı sunar.  
- 🔊 **Ses Kontrolü:** Ses çubuğu ile ses seviyesini ayarlayabilir ve sesi açıp kapatabilirsiniz.  
- 🌈 **Arayüz Renk Değiştirme:** Rastgele bir arka plan rengi seçerek uygulamanın görünümünü değiştirebilirsiniz.  
- 🔍 **YouTube Link Getirme:** Açık olan YouTube sayfasının başlığını ve linkini alarak kaydedebilirsiniz.  
- 🖥️ **Tam Ekran Modu:** Seçilen videoyu tam ekran oynatma desteği sunar.  

## 🛠️ Kullanılan Teknolojiler  
- **C#** - .NET Windows Forms  
- **SQL Server** - Veritabanı yönetimi  
- **WebView2** - YouTube videolarını gömme ve kontrol etme  
- **NAudio** - Ses kontrolü  

## 📦 Kurulum  
1. **SQL Server** yüklü olduğundan emin olun ve aşağıdaki veritabanı tablosunu oluşturun:  

```sql
CREATE TABLE TBLFILMLER (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    AD NVARCHAR(100),
    KATEGORI NVARCHAR(50),
    LINK NVARCHAR(255)
);
