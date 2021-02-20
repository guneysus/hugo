---
title: "C# İle Fonksiyonel Programlama - Currying"
date: 2021-02-20
draft: false
slug: "functional-programming-with-csharp-currying"
summary: "Fonksiyonel Programlama ile Currying"
tags:
  - csharp
  - functional-programming
  - function-delegate
  - currying
categories: []

series: "C# Functional Programming"
order: 6

thumb: /post/functional-programming-with-csharp-currying/thumbnail.png

keywords: []
publishDate:  2020-02-20T21:00+03:00
taxonomies: []
weight: 0
---

## Giriş

Serinin bu son yazısında, currying metodundan ve C# ile nasıl implemente edileceğinden bahsedeceğiz.

> Currying, birden fazla parametre alan bir fonksiyonun, tek parametre alan fonksiyona dönüştürülmesi işlemidir.

İhtiyacımız, serinin ilk yazısından da hatırlayacağınız üzere fonksiyonel programlamanın temellerinden  "fonksiyonların fonksiyon döndürebilmesi".


## Lise Matematik Bilgilerimizi Hatırlayalım

Matematik fonksiyonları ile currying yöntemini açıklamak çok daha kolay. 
Elimizde x ve y parametreleri alan bir f fonksiyonumuz olsun.

```
f(x,y) = x^2 + y^2
```

Bu fonksiyonu çağırabilmek için x ve y olarak iki farklı parametre göndermem gerekiyor.

```
f(3, 4) = 9 + 16 = 25
```

- Curry 

- Bu fonsiyonu `curry` işlemine soktuğumuzda elimizde sadece `x` parametresi alan **bir fonksiyon** olmalı
- Dönen bu fonksiyona `x` için `3`  değerini verdiğimizde, `y` parametresi alan yeni bir fonksiyon dönmeli
- Bu **ikinci fonsiyona** `y` için `4` değerini verdiğimizde nihayet `25` sonucunu vermelidir.


## C# İle Basit Bir Currying Uygulaması

Elimizde farazi bir KDV hesaplama fonksiyonu olsun. 

Öncelikle bu iki fonksiyonu kapsayacak

```csharp
decimal calculateTax(decimal money, decimal taxRate) {
    return money * taxRate;
}
```

Bu fonksiyonun delege ile temsil ediğinde imzası aşağıdaki şekilde olur:

```csharp
Func<decimal, decimal, decimal> calculator = calculateTax
//  taxRate   money    tax
```

Yukarıda, iki parametreli bu fonksiyon için iki adet ara fonksiyonun oluşacağını belirtmiştik.

```csharp
// <------ İlk fonksiyon ---------->
Func<decimal, Func<decimal, decimal>> curried = curry(calculateTax);
//            <- İkinci fonksiyon ->
```

Curried bir fonksiyonu kullanımı aşağıda şekilde.
```csharp
decimal result = curried(500)(0.18);
```


## Neden Böyle Bir Kullanıma İhtiyacımız olsun?

`calculateTax(500.00, 0.18)`  varken `curried(500.00)(0.18)`  şeklinde bir kullanıma ihtiyacımız olsun?

> Curried fonksiyonlar kısmî (`partial`) fonksiyonların özel bir türüdür. **Genel amaçlı bir fonksiyondan, yeni fonksiyonlar türeterek** özel amaçlar için benzer fonksiyonlar tekrarlarının önüne geçerek kod kalitesini artırmak içindir.

```csharp

decimal kdv = calculateTax(500.00, 0.18);
decimal otv = calculateTax(500.00, 0.05);
decimal trtPayi = calculateTax(500.00, 0.013);
```

Bunun yerine


```csharp
var curried = curry(taxCalculator);

Func<decimal, decimal> taxCalculator = curried(500.00);

var kdv = taxCalculatorFor500(0.18);
var otv = taxCalculatorFor500(0.05);
var trtPayi = taxCalculatorFor500(0.05);

```

`curried` ve `taxCalculator` fonksiyonlarını uygulamamızda tekrar tekrar kullanabilir hale geldik.


## İki Parametreli Bir Fonksiyon İçin Curry 

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