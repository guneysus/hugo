---
title: "C# İle Fonksiyonel Programlama - Map"
date: 2020-08-29
draft: false
slug: "functional-programming-with-csharp-map"
# description: 
summary: "Fonksiyonel Programlama ile Map "
tags:
  - csharp
  - functional-programming
  - function-delegate
  - map
categories: []

series: "C# Functional Programming"
order: 3

thumb: /post/functional-programming-with-csharp-map/thumbnail.png

keywords: []
publishDate:  2020-08-30T00:00+03:00
taxonomies: []
weight: 0
---


## Giriş

Önceki yazımızda fonksiyon delegelerinden bahsettik. Bu yazımızdan itibaren fonksiyonel programlama yöntemlerini C# ile uygulama yöntemlerinden bahsetmeye başlayacağız.

- Map
- Filter
- Reduce

<!-- <blockquote class="twitter-tweet"><p lang="en" dir="ltr">Map/filter/reduce in a tweet:<br><br>map([🌽, 🐮, 🐔], cook)<br>=&gt; [🍿, 🍔, 🍳]<br><br>filter([🍿, 🍔, 🍳], isVegetarian)<br>=&gt; [🍿, 🍳]<br><br>reduce([🍿, 🍳], eat)<br>=&gt; 💩</p>&mdash; Steven Luscher (@steveluscher) <a href="https://twitter.com/steveluscher/status/741089564329054208?ref_src=twsrc%5Etfw">June 10, 2016</a></blockquote> <script async src="https://platform.twitter.com/widgets.js" charset="utf-8"></script> -->

## Map

Steven'in tweeti `Map` yöntemini gayet açık şekilde açıklıyor:

{{< tweet 741089564329054208 >}}

`Cook` ismindeki fonksiyonumuz Girdi olarak 🌽, 🐮 ve 🐔 alıyor ve herbirini pişirerek 🍿, 🍔 ve 🍳'e dönüştürüyor.

## Biraz Teori

Hafifçe teorik gidelim:

Elimizde bir `f(x)` fonksiyonu olsun.

```txt
f(x) = y
```

x, sıcaklık birimi Celcius olsun ve `f(x)` fonksiyonu, Celcius birimini
Fahrenheit birimine çeviren bir fonksiyon olduğunda `f(x)` bir `Map`  (dönüşüm)
fonksiyonu diyebiliriz.

```txt
f(°C) = °F
```

## C# `Map` Kullanımı

`Map` fonksiyonunun C# dilindeki karşılığı `IEnumerable` extension metodu olan
`Select` fonksiyonudur. Bu yazımızda `Select` fonksiyonunu kullanmayacağız,
bir benzerini geliştireceğiz.

```charp
static IEnumerable<TResult> map<T, TResult>(IEnumerable<T> source, Func<T, TResult> func) {
  foreach (var element in source)
  {
    yield return func(element);
  }
}
```

<https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/select-clause>
<https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.select?view=netcore-3.1>

## Celcius ↔ Fahrenheit Dönüşüm Fonksiyonu

Celcius ↔ Fahrenheit dönüşüm fonksiyonundan yola çıkarak elimizdeki fonksiyonun
bir adet girdisi ve bir adet çıktısı olmalı. Alttaki gibi dönüşüm fonksiyonumuz
olduğunu farz edelim.

```csharp
Fahrenheit convert(Celcius value) {
  return value * 1.8 + 32.0;
}
```

## C# Delegelerini Kullanarak Kendi `Map` Fonksiyonumuzu Yazalım

Önceki yazılarımızda  `Func<T, TResult>` delegesinden bahsetmiştik. Bu dönüşüm
fonksiyonumuzu delege ile temsil etmek istersek:

```csharp
Func<Celcius, Fahrenheit> convertor = convert;
```

Elimizdeki bir Celcius veri setini, Fahrenheit değerlerine çevirecek bir
fonksiyon yazalım ve bunu delegeleri kullanarak yapalım.

### Alternatif #1

```csharp
Fahrenheit convert(Celcius value) {
  return value * 1.8 + 32.0;
}

IEnumerable<Fahrenheit> fahrenheit(IEnumerable<Celcius> values) {
  foreach(var celcius in values) {
    yield return convert(celcius);
  }
}
```

Buradaki yaklaşım fonksiyonel programlama yöntemlerine uygun olmadı:

1. `fahrenheit` fonksiyonu, parametreleri dışında `global` olan dış bir
değişkene bağımlı, yani `pure` bir fonksiyon değil.
2. `convert` fonksiyonuna direkt bağımlılık mevcut. Bunun yerine delege
kullanılmalı ve aynı işi yapabilecek herhangi bir fonksiyona ait delege
parametre olarak geçilebilmeliydi.

İki maddenin çözümü fonksiyon delegelerinde.

### Alternatif #2

```csharp
IEnumerable<Fahrenheit> fahrenheit(IEnumerable<Celcius> values, Func<Celcius, Fahrenheit> convertor) {
  foreach(var celcius in values) {
    yield return convertor(celcius);
  }
}
```

Yeni fonksiyonumuza yeni bir parametre ekledik. `convertor` delegesine uyumlu
herhangi bir fonksiyona ait delegeyi parametre olarak geçmemiz gerekli ve yeterli.

Kullanımı:

```csharp
Func<Celcius, Fahrenheit> convertor = convert;
var fahrenheitValues = fahrenheit(celciusValues, convertor);
```

### Jenerik bir `map` fonksiyonu haline getirelim

Jenerik bir `map` fonksiyonunu geliştirebilmek için elimizdeki `hardcoded` olan
tip parametrelerini jenerik hale getirmemiz yeterli olacak.

```csharp
IEnumerable<TResult> map(IEnumerable<T> values, Func<T, TResult> convertor) {
  foreach(var value in values) {
    yield return convertor(celcius);
  }
}
```

Kullanımı:

```csharp
Func<Celcius, Fahrenheit> convertor = convert;
var fahrenheitValues = map<Celcius, Fahrenheit>(celciusValues, convertor);
```

Yeni `map` fonksiyonumuzla beraber sıcaklık değer listelerini, diğer birimlere
çevirecek fonksiyonları tek tek yazmak yerine `map<T, TResult>` fonksiyonunu
kullanarak türetebileceğiz.

Örnek:

```csharp
var celciusValues = new List<Celcius>() {-1.5, 15.0, 36.5 };

var csharpToKelvin = map<Celcius, Kelvin>(celciusValues, value => value + 273.0);
var fahrenheitToCelcius = map<Fahrenheit, Celcius>(fahrenheitValues, value => (value - 32)/1.8);
```
