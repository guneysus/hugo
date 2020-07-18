---
title: ack with scoop escaping < character problem
date: 2020-02-25T12:02:18
draft: true
---

Windows üzerinde C# kodlarını aramak için [ack!](https://beyondgrep.com) aracını [scoop](https://scoop.sh) ile kullanıyorum.

Özellikle `<` ve `>` karakterlerinde sorun çıkarıyordu. DuckDuckGo ile yaptığım on beş saniyelik araştırma sonucunda
kayda değer bir hata bulamayınca sorunun Windows, Powershell veya Scoop ile alakalı olabileceğini düşünerek bir kaç deneme yaptım.

```
ack --csharp "Get<Product>"
The syntax of the command is incorrect.

ack --csharp "Get<<Product>"
<< was unexpected at this time.
```

Powershell'de `ack` yazdığımda `ack.bat` dosyasının çalıştırıldığını tespit ettim.

```bat
@perl.exe %~dp0ack-single-file %*
```

Powershell profilimde `ack.bat` scriptini ezmesi için aynı isimle yeni bir fonksiyon oluşturdum.

```powershell
Function ack () {
    perl "$HOME\scoop\apps\ack\current\ack-single-file" $args
}
```

Sonuç: ✅
