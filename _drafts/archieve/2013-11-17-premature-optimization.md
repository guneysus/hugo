---
title: "Premature Optimization"
date: "2013-11-17"
draft: true
---

Bugün speakerdeck.com'da  [^speakerdeck] bir sunum okurken rastgeldim, \"Zamansız Optimizasyon\"


## Nedir **Zamansız Optimizasyon** ?

Bazen program geliştirirken, daha programınızı yeterince test edip, dağıtım haline getirmeden, en iyi, en hızlı kodu yazmak istersiniz. Bazen bu optimizasyonlar uygulamayı çalışmaz hale getirirken, bazen de yeterince ölçüm (profiling) yapılmadığından gereksiz bile olabilirler. Kaynak kodunuz gereksiz bir şekilde kirlenir ve karmaşık hale gelir.

---

### Performans optimizasyonu yapmadan önce

#### Kesinlikle **Ölçüm (Profiling)** yapmalısınız.
Çünkü uygulamanızın **%10** zaman kaybettiği bir bölümü **%100** hızlandırmak size **%5'lik** bir artıştan başka bir şey kazandırmaz.


Orijinal metni sunumun 32. sayfasında bulabilirsiniz [^rapid-web] 

Konuyla ilgili diğer referanslar [^3] [^4]



[^rapid-web]: [https://speakerdeck.com/pyconslides/tutorial-rapid-web-prototyping-with-lightweight-tools-by-andrew-montalenti](https://speakerdeck.com/pyconslides/tutorial-rapid-web-prototyping-with-lightweight-tools-by-andrew-montalenti)

[^speakerdeck]: [https://speakerdeck.com](https://speakerdeck.com)
[^3]: [http://c2.com/cgi/wiki?PrematureOptimization](http://c2.com/cgi/wiki?PrematureOptimization)
[^4]: The Premature Optimization Is Evil Myth (Google Önbelleği) [http://www.bluebytesoftware.com/blog/2010/09/06/ThePrematureOptimizationIsEvilMyth.aspx](http://webcache.googleusercontent.com/search?q=cache:UXODZz3p4nUJ:joeduffyblog.com/2010/09/06/the-premature-optimization-is-evil-myth/+&cd=1&hl=en&ct=clnk&gl=tr)


<a href=\"\" rel=\"nofollow\"></a>