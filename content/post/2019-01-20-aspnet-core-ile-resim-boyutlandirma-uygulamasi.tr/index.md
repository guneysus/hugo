---

title: "ASP.Net Core İle Resim Boyutlandırma Uygulaması"
date: 2019-01-20T20:23:00+03:00
draft: false

description: Aspnet Core, ImageSharp kullanarak restful standartlara uymaya çalışarak bir API geliştirip, nodejs ile bu API'yi Docker ile test edeceğiz.
summary:	ImageSharp ile temel bir resim boyutlandırma web API uygulamasının, Docker ile çalıştırıp nodejs supertest ile test edeceğiz.

thumb: /static/ASP.NET-Core-Logo_2colors_RGB_bitmap_MEDIUM.png
thumbAlt: aspnet core image server

tags: 
    - test driven
    - e2e testing
    - aspnet core
    - docker
    - nodejs
    - supertest
    - aws
    - side project

slug: aspnet-core-1-image-server
keywords: []
publishDate: 2019-01-20T20:23:00+03:00
taxonomies: []
weight: 0

---


## Giriş

Bu yazımda [ImageSharp][imagesharp] ile basit bir resim boyutlandırma uygulamasını nasıl yazıp geliştirdiğimden bahsedeceğim. Uygulamamızın ön yüzü olmayacak, API olarak çalışacak.
Docker ile paketleyeğiz. Ve bence en önemlisi uygulamamızın özelliklerini HTTP istekleriyle test etmeye yarayan nodejs [supertest][supertest] ile test edeceğiz.

## Tasarım Prensipleri

- Restful standartlara uygun bir API tasarlayacağız.
- Stateless tasarlamayı düşünüyordum, henüz tamamlayamadım. Şu anda dosyalar konteyner üzerine upload ediliyor ve bu **kesinlikle ve kesinlikle** canlı ortamda kullanılmaması gereken bir yöntem. Docker containerları üzerinde kalıcı veri tutmayınız. Host makine üzerinde bir klasöre, konteyner içindeki bir klasörü bağlamak çözümlerden biri. Dosyaları AWS S3'e yüklemek ise planladığım çözüm.
- Dosyaların sadece orijinal hallerini depolayacağız. Resimlerin  boyutlandırılmış hallerini istek anında işleyip (`on-the-fly`) sunacağız, depolamayacağız.
- Olabildiğince basit ve kullanılabilir halde temel özelliklerden oluşan bir uygulama geliştireceğiz.
- Uygulamayı Docker ile derleyip ayağa kaldıracağız.
- Sadece temel fonksiyonları "yeteri" kadar test edeceğiz.

## Uygulamanın Özellikleri

- Tekli ve çoklu resim yükleme
- Mevcut resmi değiştirme
- Resim silme
- Sabit genişlik ve sabit yükseklikte resimleri boyutlandırma.

Bu kadar.

Bu adrese dosyamızı gönderiyoruz.

```
POST /api/upload
```

Buradan alıyoruz. Yükseklik *0* olduğunda resmin orijinali döndürülür.

```
GET /image/h{height}/{name}
```

## Nasıl Test Edeceğiz

Test kodları ise [burada][src-test]. Yazılmışı var.

Kısa bir örnek verelim:

Aşağıdaki kod, test için gerekli tanımlamaları yaptıktan sonra `'_data/ZY-IMG_0091-635px.jpg'` dosyasını yükler ve dönen sonucun 200 olmasını ve sonucun içinde _jpg_ geçmesini bekler.

{{% attachment lang="js" path="src/tests.js" title="Tests" name="tests.js" /%}}

## Bu testleri de Dockerize edelim

{{% attachment lang="Dockerfile" path="src/Dockerfile" title="Dockerfile" name="Dockerfile" /%}}

## Peki Nasıl Çalıştıracağız

Proje içinde bir [Makefile][makefile] var. İçinde ihtiyacınız olan komutlar hatta gereksiz derece fazlalık komutlar bile mevcut. `make up` demeniz yeterli. Veya docker-compose ile projeyi kolayca ayağa kaldırabilirsiniz.

Biri test, diğer uygulama olmak üzere iki konteyner ayağa kalkacak ve testler çalışacak.
Şu an sekiz testten birinin başarısız olması gerekiyor.

```shell
docker-compose up --renew-anon-volumes --build
```

## Kodlar

[Kodlar Burada][src]

<!-- ----------------- -->

[imagesharp]:   https://github.com/SixLabors/ImageSharp  "SixLabors/ImageSharp"

[supertest]:    https://github.com/visionmedia/supertest  "visionmedia/supertest"
[src]:          https://github.com/guneysus/dotnetcore-imageserver/tree/master/src/ImageServer
[src-test]:    https://github.com/guneysus/dotnetcore-imageserver/tree/master/tests
[makefile]:    https://github.com/guneysus/dotnetcore-imageserver/blob/master/Makefile
