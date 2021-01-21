---
title: "C# İle Fonksiyonel Programlama - Reduce"
date: 2021-01-11
draft: false
slug: "functional-programming-with-csharp-reduce"
summary: "Fonksiyonel Programlama ile Reduce"
tags:
  - csharp
  - functional-programming
  - function-delegate
  - reduce
categories: []

series: "C# Functional Programming"
order: 5

thumb: /post/functional-programming-with-csharp-reduce/thumbnail.png

keywords: []
publishDate:  2020-12-26T23:00+03:00
taxonomies: []
weight: 0
---

## Giriş

Bu yazımız görsel ağırlıklı olacak.

`Reduce`, boyutu küçültme anlamına gelir. Bir array üzerinde işlem yapıp, daha küçük boyutlu (genellikle tek elemanlı) bir dizi elde etme işlemi `Reduce`, SQL ifadesiyle bir `Aggregate` işlemidir.

Aslında `Filter` işlemi de `Reduce` ile tanımlanabilse de genellikle `Reduce` işlemi sonucunda tek elemanlı bir sonuç çıkması gerektiği farzedilir.

1 ile 6 arasındaki sayılar bir array, bu sayıların toplamı veya faktöryeli ise bir `Reduce` işlemidir.


### Reduce Uygulaması

`Reduce` algoritmasını uygulayabilmek için:

1. İlk adımda array'in ilk iki elemanı alınır ve `Reducer` fonksiyonu ile ilk değer hesaplanır
2. Diğer adımlarda `Reducer` fonksiyonun ilk parametresi geçmişten gelen sonuç, diğer parametre ise array'in bir sonraki elemanı olur.
3. Son elemana gelindiğinde `Reducer` fonksiyonundan çıkan değer sonuç olur.
4. Bazı durumlarda `Reducer` fonksiyonu için başlangıç değeri (`seed`) verilir böylece ilk adımda array'in ilk elemanı ile bu değer `reducer` fonksiyonuna girer.


#### Örnek:

1'den 6'ya kadar olan sayıları toplamak istediğimizi farzedelim.

```
[1,2,3,4,5,6]

reducer(a,b) -> return a + b;

1. reducer(1,2) => 3
2. reducer(3,3) => 6
3. reducer(6,4) => 10
4. reducer(10,5) => 15
5. reducer(15, 6) => 21
                     ^^
```


<figure class="video_container">
  <video allowfullscreen="false" poster="img/reduce-illustration-1.jpg" width="400px" loop autoplay preload controls>
    <source src="img/reduce-illustration.mp4" type="video/mp4">
    <source src="img/reduce-illustration.mkv" type="video/mkv">
    <source src="img/reduce-illustration.webm" type="video/webm">
  </video>
</figure>
