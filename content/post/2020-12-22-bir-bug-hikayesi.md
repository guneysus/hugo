---
title: "Bir Bug Macerası"
date: 2020-12-22T23:47:00+03:00
draft: true
summary: "TODO"
---

Ünlü bir düşünürün de dediği gibi:

> Seni öldürmeyen bug güçlendirir.

Hayatımda daha ötesini görebileceğimi sanmadığım buglardan birine bu sene denk geldim. Bir web uygulamasındaki hangi özellik bilgisayara mavi ekran verdirebilir?

Bir ay içinde raporlanmaya başlayan ve zamanla sıklığı artmaya başlayan bir mavi ekran hatası ekibin korkulu rüyası oldu. İşin garip tarafı farklı antivirüs programı, farklı marka ve model bilgisayarlarda hata tekrar edilebiliyordu. Daha da garibi, hata sadece development ortamlarında alınıyor ve login olduktan sonraki "bazı" ekranlarda sık sık veya mutlaka karşımıza çıkıyordu.

İlk akla gelen önermelerden biri datalarımızda recursive olmasıydı, pek inanmasam da gerçekten mavi ekran hatası artık alınmıyordu.

Ertesi gün, bordo bereli bugımız arz-ı endam etmeye başladı. Yüzden fazla kişinin işini yapmasına engel olan ve ne zaman ortaya çıktığı belli olmayan bir bug, sizi de heyecanlandırmaz mıydı?

Ekipteki birçok kişi sorunu araştırmaya çalışıyordu. Antivirüs uygulamaları da değerlendirildi, fakat sonuç alınamadı. Soruna şu şekilde yaklaştım:

**Mavi ekran aldırdıktan sonra memory dumpları inceledim**

Bazı memory dumplarda en son antivirüs programı çağrıları görsem de memorydump analizi işinin beni aştığını düşünerek vazgeçtim. 

**Chrome ile ilgili bir bug olabileceğini değerlendirdim**

Firefox ile çalışmaya başladım ve mavi ekranın burada alınmadığını farkettim. Ekibe hemen mail atıldı fakat sorunun sebebini hala bilmiyorduk. Bug ile ilgilenmeyi bırakarak development işlerine devam etmeye başladım.

Network tools açıkken nasıl olduysa Chrome ile Firefox arasındaki bir davranış farkı dikkatimi çekti, response type. Sunucu, iki tarayıcıya responsları farklı bir formatta gönderiyordu: **Brotli**

Brotli, tıpkı webp gibi tarayıcıdan gelen bir headera göre sunucudan gelse de Firefox'un farklı bir davranışı daha vardı.

> Firefox sadece TLS içeren sayfalarda brotli desteklediğini sunucuya belirttiği için localhost'de mavi ekran hatasını tekrar edemiyorduk.

Brotli desteğinin nispeten yeni olduğunu bildiğimden bu özelliğin deneysel özelliklerden kapatılıp kapatılamadığını kontrol ettim, default olarak açık geldiğini ve kapatılamadığını gördüğümü hatırlıyorum.
Bu sebepten olsa gerek, bulabildiğim eski Chrome sürümlerini araştırdım, scoop üzerinden Chromium'un 67 versiyonunu bulabildim veeee:

- Brotli, bu versiyonda deneysel olduğu için istediğim an kapatıp açabiliyordum.

Bu özelliği kapattığımızda hatanın kaybolduğunu gördükten sonra ekibe ilettik.
Emin olabilmek için, koddan bu özelliği kapatarak diğer Chrome versiyonları ve ekip arkadaşlarının bilgisayarlarında da denedikten sonra özelliği development ortamlarında kapattık.

Hatanın tek tük raporlanmaya başladığı tarihle özelliğin çıkış tarihinin aynı gün (bir ay kadar öncesi) olması da bu sefer hatayı tespit ettiğimizi gösteriyordu.

