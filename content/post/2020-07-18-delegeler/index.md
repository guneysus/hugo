---
title: "C# İle Fonksiyonel Programlamaya Giriş - Delegeler"
date: 2020-07-18
draft: false
slug: "functional-programming-with-csharp-intro-delegates"
summary: "Bu kısa yazıda fonksiyonel programlama paradigmalarını C# ile uygulayabilmek için `delegate` türlerini tanıyıp kullanacağız"
tags:
  - csharp
  - functional-programming
---

## Fonksiyonel Programlama Nedir

Fonksiyonel programlama, gerçek hayattaki problemlere bakış açımızı değiştiren
bir yaklaşımdır.

Fonksiyonel yaklaşım için en temel gereksinimler:

- Fonksiyonların değişkenler gibi tanımlanabilmesi
- Fonksiyonların, fonksiyon tipindeki döndürebilmesi
- Fonksiyonların, diğer fonksiyonlara parametre olarak geçilebilmesi
- Fonksiyonların etkileşime girebilmesi

gereklidir.

## Delegeleri Tanıyalım

`delegate` türü, fonksiyonları kapsayan ve temsil edebilen türlerdir.
Fonksiyonları değişken ve parametreler olarak ele alabilmek için delegeleri yoğun
şekilde kullanacağız.

**Örnek:**

`static Console.WriteLine(string value)` konsol fonksiyonumuz için bir delege
tanımlayalım ve bu fonksiyonu çağırmak için tanımlayacağımız delegeyi kullanalım.

```csharp
 public delegate void Writer(string message);

 void Main()
 {
   Writer consoleWriter = Console.WriteLine;
   consoleWriter("Hello");
 }
```

Başta kafa karıştırıcı gelebilir. `var a = Console.WriteLine` gibi bir atama
yapmamız mümkün değilken `Console.WriteLine` fonksiyonunu bir değişkene
atayabiliyoruz.

{{% notice note %}}
Bir fonksiyonu, bir delegeye atayabilmek için parametre ve dönüş tiplerinin
örtüşmesi gereklidir.
{{% /notice %}}

`Console.WriteLine` fonksiyonunun birden fazla overload türü olduğu için
derleyici bizim yerimize uygun olanı seçti.

### `Action`, `Func` Delege Türleri ve Türevleri

`Action`, `Func`, `Func<T1, …>`, `Action<T1, …>` şeklindeki delegeler,
yukarıda `Writer` şeklinde yaptığımız tanımdan hiçbir farkı olmayan, .NET ile
beraber gelen delege türleridir.

Action ve Func arasındaki tek ve önemli fark, `Action` adındaki delegelerin
`void` tipi dönen fonksiyonları temsil edebilmesidir.

{{% notice note %}}
Kendi frameworkünüzü yazmak veya CLR kullanmadan uygulama geliştirmek gibi özel
sebepleriniz yoksa `Func` ve `Action` türlerindeki delegeleri kullanmalısınız.
{{% /notice %}}

### Fonksiyon Döndüren Fonksiyon

Yukarıda yaptığımız örneği bir adım ileri götürelim:

```csharp
 public delegate void Write(string message);

 void Main()
 {
   Write writer1 = WriterFactory();
   Write writer2 = WriterFactory();
   writer1("via Writer#1");
   writer2("via Writer#2");
 }

 Write WriterFactory () {
   Write writer = Console.WriteLine;
   return writer;
 }
```

`WriterFactory` fonksiyonundan `Console.WriteLine` fonksiyonunu döndürdük.

## Sonuç

Örneğimizde bir `WriterFactory` fonksiyonundan `void Write(string message)`
delegesine uyumlu bir fonksiyon döndürerek aynı zamanda bir soyutlama yapmış
olduk.

Bir sonraki fonksiyonel programlama yazımız, delegelerde jenerik türlerin
kullanımı üzerine olabilir. Daha sonra ise kala iki madde hakkında kısa ve
öğretici uygulamalar yapmayı planlıyoruz.

- ~~Fonksiyonların değişkenler gibi tanımlanabilmesi~~
- ~~Fonksiyonların, fonksiyon tipindeki döndürebilmesi~~
- Fonksiyonların, diğer fonksiyonlara parametre olarak geçilebilmesi
- Fonksiyonların etkileşime girebilmesi

{{% notice info %}}
**☕**

`writer1` ve `writer2` delegeleri  `C:\fn.log` dosyasına ekleme yapacak şekilde
`WriterFactory` fonksiyonunu güncelleyin.
{{% /notice %}}

---
**Referanslar:**

- [Functional programming (wikipedia)](https://en.wikipedia.org/wiki/Functional_programming)
- [Using Delegates (C# Programming Guide)
](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/delegates/using-delegates)
- [Action Delegate](https://docs.microsoft.com/en-us/dotnet/api/system.action)
- [Func\<TResult> Delegate](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)
