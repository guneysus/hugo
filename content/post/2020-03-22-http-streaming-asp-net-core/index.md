---
title: "HTTP Streaming ve Scalability"
slug: http-streaming-asp-net-core
date: 2020-03-22T13:50:03+03:00
draft: true
tags:
    - scalability
    - http
    - streaming
---

Web uygulamaları geliştirirken son kullanıcıya olabildiğince hızlı şekilde web sayfalarını gösterebilmek için hem sunucu tarafında hem tarayıcı tarafında yatırım ve optimizasyonlar yaparız.
Daha güçlü **CPU**, daha yüksek **RAM**, daha fazla **Network** ile bir yandan bu süreleri aşağı çekmeye çalışırken, anlık kullanıcı limitlerimizi de mümkün olduğunda **lineer** şekilde artırabilmek diğer bir ifadeyle **ölçekleyebilmek** isteriz.

Bu yazımızda kaynak olarak RAM'i ele aldığımızı vurgulamak isterim.

## Lineer…

İdeal şartlarda.

Bir (1) sunucunuz varsa ve anlık kullanıcı sayınız yüz (100) ise, eşdeğer bir sunucuyu load balancer önüne koyduğunuzda iki yüz (200) kullanıcıyı sisteminizin kaldırabilmesi demektir.

## Sunucu Sayısını Artırmadan Ölçeklenebilirlik Mümkün mü

İkinci sunucuyu load balancer arkasına koymamızın asıl sebebi, kullanıcı başına düşen kaynak miktarını artırarak performans artışını sağlamaktı. Kullanıcı başına kaynak miktarını azaltabilirsem, sunucu sayısını artırmadan ölçeklenebilirlik mümkün olabilir.

1. Uygulamanızın RAM tüketimini azaltarak ve memory-leakleri tespit ederek
1. Daha az kaynak tüketen
   - Framework ve kütüphaneler
   - Dil
   - Platform kullanarak
1. Kullanının istek (request) başına tükettiği kaynak miktarını minimize ederek uygulamanızı ölçekleyebilirsiniz.

## HTTP Streaming

Kullanıcının istek başına tükettiği kaynak miktarını azaltmanın yollarından biri, istekleri streaming yöntemiyle son kullanıcıya aktarmaktır.

Büyük bir su varilindeki suyun kaynağımız olsun ve her istek başına ayrılan RAM miktarı da bu varilin alt tarafında açılacak de