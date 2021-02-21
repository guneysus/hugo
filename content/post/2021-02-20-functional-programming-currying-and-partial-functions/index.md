---
title: "C# İle Fonksiyonel Programlama - Currying"
date: 2021-02-20
draft: false
slug: "functional-programming-with-csharp-currying-and-partial-functions"
summary: "Serinin son yazısı: Currying ve Kısmî Fonksiyonlar"
tags:
  - csharp
  - functional-programming
  - function-delegate
  - currying
categories: []

series: "C# Functional Programming"
order: 6

thumb: /post/functional-programming-with-csharp-currying-and-partial-functions/thumbnail.png

keywords: []
publishDate:  2020-02-20T21:00+03:00
taxonomies: []
weight: 0
---

## Giriş

Serinin son yazısında, currying metodundan ve C# ile nasıl implemente edileceğinden bahsedeceğiz.

> Currying, birden fazla parametre alan bir fonksiyonun, tek parametre alan fonksiyona dönüştürülmesi işlemidir.

İhtiyacımız, serinin ilk yazısından da hatırlayacağınız üzere fonksiyonel programlamanın temellerinden  "fonksiyonların fonksiyon döndürebilmesi".


## Lise Matematik Bilgilerimizi Hatırlayalım

Matematik fonksiyonları ile currying yöntemini açıklamak çok daha kolay. 
Elimizde x ve y parametreleri alan bir `f(x,y)` fonksiyonumuz olsun.


**f(x,y) = x<sup>2</sup> + y<sup>2</sup>**


Bu fonksiyonu çağırabilmek için `x` ve `y` olarak iki farklı parametre göndermemiz gerekiyor.

**f(3, 4) = 3<sup>2</sup> + 4<sup>2</sup> = 25**
>

- Bu fonkiyonu `curry` işlemine soktuğumuzda, sadece `x` parametresi alan **yeni bir fonksiyon** dönmeli,
- Dönen bu fonksiyona `x` için `3`  değerini verdiğimizde, `y` parametresi alan **ikinci bir fonksiyon** dönmeli,
- Bu ikinci fonsiyona `y` için `4` değerini verdiğimizde nihayet `25` sonucunu vermelidir.


## Kısmî Fonksiyon Nedir?

> Kısmî (`partial`) fonksiyon, parametrelerin bazılarının metoda daha sonra geçilebildiği fonksiyonlardır. 

Beş parametreli bir fonksiyonun ilk parametresini şimdi, kalan dört parametreyi daha sonra geçebilmek için `Func` delegesini kullanacağız.

### Curried Fonksiyon

Curried fonksiyonlar kısmî fonksiyonların özel bir türüdür. Dönüştürülen fonksiyonlar daima tek parametre aldığında **`curried`**, birden fazla parametre aldığında ise **`partial`** olarak adlandırılır.


## C# İle Basit Bir Currying Uygulaması

Elimizde farazi bir KDV hesaplama fonksiyonu olsun. 

```csharp
decimal calculateTax(decimal money, decimal taxRate) {
    return money * taxRate;
}
```

Bu fonksiyonun imzası aşağıdaki şekilde olur:

```csharp
Func<decimal, decimal, decimal> calculator = calculateTax
//   money    taxRate  tax
```

Yukarıda, iki parametreli bu fonksiyonun iki dönüşüm geçirerek, iki  adet ara fonksiyonun oluşacağını belirtmiştik. Diğer ifadeyle `25` sonucuna ulaşabilmek için fonksiyonumuz iki `currying` aşamasından geçecek.


```csharp
// <------ İlk fonksiyon ---------->
Func<decimal, Func<decimal, decimal>> curried = curry(calculateTax);
//            <- İkinci fonksiyon ->
```

`Curried` bir fonksiyonun kullanımı aşağıda şekilde.
```csharp
decimal result = curried(500)(0.18);
```


## Neden Böyle Bir Kullanıma İhtiyacımız olsun?

`calculateTax(500.00, 0.18)`  varken neden `curried(500.00)(0.18)`  şeklinde bir kullanıma ihtiyacımız olsun?


> **Genel amaçlı bir fonksiyondan, yeni fonksiyonlar türeterek** özel amaçlar için benzer fonksiyonlar tekrarlarının önüne geçerek kod kalitesini artırmak için.


### `Currying` Olmadan

```csharp
decimal kdv = calculateTax(500.00, 0.18);
decimal otv = calculateTax(500.00, 0.05);
decimal trtPayi = calculateTax(500.00, 0.013);
```

### `Currying` Kullanarak

```csharp
var curried = curry(taxCalculator);
Func<decimal, decimal> taxCalculator = curried(500.00);

var kdv = taxCalculatorFor500(0.18);
var otv = taxCalculatorFor500(0.05);
var trtPayi = taxCalculatorFor500(0.05);
```

Daha fazla kod yazdık, fakat aşağıdaki fonksiyonların tekrar kullanılabilir olduklarına dikkat edin:

- `taxCalculator`
- `taxCalculatorFor500`

`taxCalculator` genel amaçlı, `taxCalculatorFor500` ise özel amaçlı türetilmiş bir fonksiyondur. Yaptığımız işlem, fonksiyonun ilk parametresi `500.00` değerini önceden geçerek kısmî bir fonksiyon türetmek.

Devletimiz, yeni bir vergi çıkardığında tek yapmamız gereken, `taxCalculatorFor500` fonksiyonunu vergi oranı ile çağırarak yeni vergi tutarını hesaplamak olacak.

## İki Parametreli Bir Fonksiyon İçin Jenerik Curry Fonksiyonu

Aşağıdaki kodu language-ext [^language-ext] kütüphanesinden aldım. 10 parametreli bir fonksiyon için `curry` ihtiyacınız olursa 115. satıra bakabilirsiniz.

```csharp
/// <summary>
/// Curry the function 'f' provided.
/// You can then partially apply by calling: 
/// 
///     var curried = curry(f);
///     var r = curried(a)(b)
/// 
/// </summary>
[Pure]
public static Func<T1, Func<T2, R>> curry<T1, T2, R>(Func<T1, T2, R> f) =>
    (T1 a) => (T2 b) => f(a, b);
```


[^language-ext]: Haskell fonksiyonel yöntemlerini C#'a uyarlayan ilginç bir kütüphane. [github](https://github.com/louthy/language-ext/blob/main/LanguageExt.Core/Prelude/Prelude_Curry.cs#L17)

[^partial-functs]: https://github.com/louthy/language-ext/wiki/Thinking-Functionally:-Partial-application
