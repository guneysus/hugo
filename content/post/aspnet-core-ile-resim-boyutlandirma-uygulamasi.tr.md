---

title: "Aspnet Core İle Resim Boyutlandırma Uygulaması"
date: 2019-01-20T20:23:00+03:00
draft: false

description: Aspnet Core, ImageSharp kullanarak restful standartlara uymaya çalışarak bir API geliştirip, nodejs ile bu API'yi Docker ile test edeceğiz.
tags: 
    - asp.net core
    - nodejs
    - supertest
    - test driven
    - e2e


categories:
    - Asp.NET Core
    - Amazon Web Services
    - Docker
    - Side Projects

slug: aspnet-core-1-image-server
keywords: []
publishDate: 2019-01-20T20:23:00+03:00
taxonomies: []
weight: 0

---

## Giriş

Bu yazımda [ImageSharp][imagesharp] ile basit bir resim boyutlandırma uygulamasını nasıl yazıp geliştirdiğimden bahsedeceğim. Uygulamamızın ön yüzü olmayacak, API olarak çalışacak.
Docker ile paketleyeğiz. Ve bence en önemlisi uygulamamızın özelliklerini HTTP istekleriyle test etmeye yarayan nodejs [supertest][supertest] ile test edeceğiz.

---

## Tasarım Prensipleri

- Restful standartlara uygun bir API tasarlayacağız.
- Stateless tasarlamayı düşünüyordum, henüz tamamlayamadım. Şu anda dosyalar konteyner üzerine upload ediliyor ve bu **kesinlikle ve kesinlikle** canlı ortamda kullanılmaması gereken bir yöntem. Docker containerları üzerinde kalıcı veri tutmayınız. Host makine üzerinde bir klasöre, konteyner içindeki bir klasörü bağlamak çözümlerden biri. Dosyaları AWS S3'e yüklemek ise planladığım çözüm.
- Dosyaların sadece orijinal hallerini depolayacağız. Resimlerin  boyutlandırılmış hallerini istek anında işleyip (`on-the-fly`) sunacağız, depolamayacağız.
- Olabildiğince basit ve kullanılabilir halde temel özelliklerden oluşan bir uygulama geliştireceğiz.
- Uygulamayı Docker ile derleyip ayağa kaldıracağız.
- Sadece temel fonksiyonları "yeteri" kadar test edeceğiz.

---

## Uygulama

Kodları anlatmayacağız. [Burada][src] yazılmışı var 😒

---

## Uygulamanın Özellikleri

- Tekli ve çoklu resim yükleme
- Mevcut resmi değiştirme
- Resim silme
- Sabit genişlik ve sabit yükseklikte resimleri boyutlandırma.

Bu kadar.

Bu adrese dosyamızı gönderiyoruz.

```http
POST /api/upload
```


Buradan alıyoruz. Yükseklik *0* olduğunda resmin orijinali döndürülür.

```http
GET /image/h{height}/{name}
```

---

## Nasıl Test Edeceğiz

Test kodları ise [burada][src-test]. Yazılmışı var. 

Kısa bir örnek verelim:

Aşağıdaki kod, test için gerekli tanımlamaları yaptıktan sonra `'_data/ZY-IMG_0091-635px.jpg'` dosyasını yükler ve dönen sonucun 200 olmasını ve sonucun içinde _jpg_ geçmesini bekler.


```js
var should = require("chai").should(),
  expect = require("chai").expect,
  supertest = require("supertest"),
  API_URL = "http://app:5000",
  api = supertest(API_URL);

describe("JPEG File Upload", function() {
  it("single JPEG file upload", function(done) {
    api
      .post("/api/upload")
      .set("Content-Type", "multipart/form-data")
      .attach("image", "_data/ZY-IMG_0091-635px.jpg")
      .expect(200)
      .expect("Content-Type", /text\/plain/)
      .expect(/jpg/)
      .end(function(err, res) {
        if (err) {
          return done(err);
        }
        uploadedfile = res.text;

        done();
      });
  });
});
```

## Bu testleri de Dockerize edelim:


```Dockerfile
FROM node:8
WORKDIR /usr/src/app
COPY package*.json ./

RUN npm install
COPY . .

CMD [ "node_modules/.bin/mocha", "--timeout", "25000", "--colors", "--reporter", "mocha-jenkins-reporter"]
```

---

## Peki Nasıl Çalıştıracağız?

Proje içinde bir [Makefile][makefile] var. İçinde ihtiyacınız olan komutlar hatta gereksiz derece fazlalık komutlar bile mevcut. `make up` demeniz yeterli. Veya docker-compose ile projeyi kolayca ayağa kaldırabilirsiniz.

Biri test, diğer uygulama olmak üzere iki konteyner ayağa kalkacak ve testler çalışacak.
Şu an sekiz testten birinin başarısız olması gerekiyor.

```shell
docker-compose up --renew-anon-volumes --build
```


<!-- ----------------- -->

[imagesharp]:   http://example.com/  "Optional Title Here"

[supertest]:    http://example.com/  "Optional Title Here"
[src]:          https://github.com/guneysus/dotnetcore-imageserver/tree/master/src/ImageServer
[src-test]:    https://github.com/guneysus/dotnetcore-imageserver/tree/master/tests
[makefile]:    https://github.com/guneysus/dotnetcore-imageserver/blob/master/Makefile
