
# Mvc Proje Kampı

Bu proje geliştirilirken Ekşi Sözlük vb. bir internet sitesini göz önüne alarak geliştirme yaptım. Yazarlar kendilerine özel geliştirilmiş panel üzerinden yeni başlıklar açabiliyor,
 başlıklara içerikler yazabiliyor, diğer kullanıcılarla mesajlaşabiliyor; adminler kendilerine özel geliştirilmiş panel aracılığıyla site arayüzünden gönderilen iletişim mesajlarını okuyabiliyor,
 yeni başlıklar oluşturabiliyor, yetkilendirme işlemlerini yapabiliyor, sistemdeki görselleri galeri aracılığıyla görebiliyor ve tabloları "CSV, Excel veya PDF" şeklinde export edebiliyorlar.
 Sistem 2 ana panel üzerine kurulmuştur: Yazar Paneli ve Admin Paneli.
## Yazar Paneli

Yazarlar/Kullanıcılar sisteme üye olarak Yazar Paneli'ne giriş yapabiliyorlar. Şifreleri Hashleme algoritmaları aracılığıyla veritabanında hashlenerek tutuluyor.
Yazarlar bu panel aracılığıyla aşağıdaki işlemleri gerçekleştirebiliyorlar:

- Profilim sayfasında kişisel bilgilerini güncelleyebiliyor.
- Başlıklarım sayfasında kendi oluşturduğu başlıkları görüntüleyebiliyor.
- Tüm Başlıklar sayfasında sistemdeki tüm başlıkları görüp istediği başlığı seçerek ilgili başlığa içerik yazabiliyor.
- Mesajlar sayfasında kendisine gelen mesajlar ve kendisinin gönderdiği mesajları görebiliyor.
- Yazılarım sayfasında kendi yazdığı içerikleri ve içeriklerin ait olduğu başlık bilgisini tarih/zaman bilgileriyle beraber görüntüleyebiliyor.
## Admin Paneli

Admin sisteme üye olarak kendisine atanan Rol yetkileri dahilinde Admin Paneli'ne giriş yapabilir. Burada da şifre bilgileri hashlenerek veritabanınıda tutulur. Adminler bu panel aracılığıyla aşağıdaki
işlemleri gerçekleştirebilirler:
- Kategoriler sayfasından kategori ekleme/silme/güncelleme/listeleme ve listeyi export etme işlemlerini yapabilirler.
- Yazarlar sayfasında sistemdeki yazarların listesini ve bilgilerine erişebilirler.
- Başlıklar sayfasında sistemdeki başlıkları listeleme/güncelleme/ekleme/silme işlemlerini gerçekleştirebilirler.
- İletişim & Mesajlar sayfasından ise kendilerine direkt olarak gelen mesajları ve kendilerinin diğer kullanıcılara gönderdikleri direkt mesajlara ek olarak sitenin son kullanıcı arayüzündeki iletişim formuna
 yazılan mesajları da görüntüleyebilmektedir.
- Galeri sayfası aracılığıyla sistemdeki görselleri görüntüleyebilmektedir.
- Grafik sayfası aracılığıyla da Google Chart ile oluşturduğum Pie grafiğini görebilmektedir.
- Yetkilendirmeler sayfası aracılığıyla sisteme yeni admin ekleyebilir, adminlerin yetkilerini değiştirebilir veya yetkilerini pasifleştirebilirler.
## Proje Özellikleri

- Asp.Net Mvc5 ile geliştirildi.
- Veritabanı olarak MSSQL tercih edildi.
- N Katmanlı Mimari kapsamında (BusinessLayer, DataAccessLayer, EntityLayer, PresentationLayer) geliştirildi.
- SOLID prensiplerine olabildiğince bağlı kalınmaya çalışıldı.
- Fluent Validation kullanıldı.
- Entity Framework ile Code First yaklaşımıyla geliştirildi.
- Çeşitli scriptler (örneğin, datagrid) kullanıldı.
- Oturum yönetimi Session ile gerçekleştirildi. Güvenlik için Authorize ve Authentication'lar kullanıldı.
- Google Charts ve Sweet Alert kullanıldı.
- Özel hata sayfaları (404) oluşturuldu.

  
## Kullanılan Teknolojiler

- Code First / EntityFramework
- Authentication / Authorize / Fluent Validation
- MSSQL
- LINQ Sorguları
- Partial Views
- Sweet Alert / Google Chart
- DataTable / Pagination / Searching
- Custom Error Pages
## Ekran Görüntüleri
![screencapture-localhost-44375-Login-Index-2024-12-13-23_29_43](https://github.com/user-attachments/assets/a8bc840b-3648-43eb-86de-2fb4fc503429)
![screencapture-localhost-44375-AdminCategory-2024-12-13-23_30_04](https://github.com/user-attachments/assets/352e01cf-fc8e-4066-a764-6195aa23d038)
![screencapture-localhost-44375-Contact-Index-2024-12-13-23_30_36](https://github.com/user-attachments/assets/d1208f2f-7437-468d-8cd2-1f306aa35245)
![screencapture-localhost-44375-Default-Headings-2-2024-12-13-23_29_30](https://github.com/user-attachments/assets/c04ea6c0-6a41-4eb3-b88e-79cbb61f685a)
![screencapture-localhost-44375-ErrorPage-Page404-2024-12-13-23_30_44](https://github.com/user-attachments/assets/4eb5bc5d-537d-46b5-9a02-26ce7c157247)
![screencapture-localhost-44375-Gallery-Index-2024-12-13-23_30_53](https://github.com/user-attachments/assets/c04c0e9d-4e10-4af5-bfe4-21d260af47c2)
![screencapture-localhost-44375-Writer-Index-2024-12-13-23_30_13](https://github.com/user-attachments/assets/237ec7d9-9362-4d8f-ac20-35fb6d12c641)
![screencapture-localhost-44375-Login-WriterLogin-2024-12-13-23_26_44](https://github.com/user-attachments/assets/c17663e8-7e0e-439f-9a8d-24082ef87843)
![screencapture-localhost-44375-WriterPanel-AllHeading-2024-12-13-23_28_42](https://github.com/user-attachments/assets/4a013004-e8d4-4d10-ae30-64e9e2ad24e5)
![screencapture-localhost-44375-WriterPanelContent-MyContent-2024-12-13-23_29_00](https://github.com/user-attachments/assets/903be3fa-9b72-4120-8398-16e93d78df10)
![screencapture-localhost-44375-WriterPanelMessage-Inbox-2024-12-13-23_28_52](https://github.com/user-attachments/assets/696d5608-99e3-46d4-b037-f95fa5ac72ab)
![screencapture-localhost-44375-WriterPanel-MyHeading-2024-12-13-23_27_55](https://github.com/user-attachments/assets/1017eaa5-ea61-4e42-bee7-280bc32764dd)
![screencapture-localhost-44375-WriterPanel-WriterProfile-2024-12-13-23_27_46](https://github.com/user-attachments/assets/84dc1838-7c11-4dff-82ff-d443dfbf4c00)

