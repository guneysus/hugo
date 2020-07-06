---
draft: true
title: How .NET Works
tags:
  - what-happens-when
---


# giriş

## .NET Mimarisi

- Source
- MSIL
  - Base Class Library (BCL): Shared among all languages
  - Common Language Runtime (CLR): Hosts managed code
- JIT
- Executable

## CLR

Common Type System (CTS)
- Specifies rules for class, struct, enums, interface, delegate, etc

Execution Engine (EE)

- Compiles MSIL into native code
- garbage collection
- exception
- CAS
- Handles verification



## .NET Uygulaması Çalıştırıldığında Neler Olur

- PE dosyasının parse edilmesi
- Giriş noktasının adresinin bulunması
- mscoree.dll!_CorExeMain metodunu çağırılması
- JIT'in MSIL kodlarını makine kodlarına dönüştürmesi
- İstiklal Marşı
- Kapanış

---

- <https://www.c-sharpcorner.com/UploadFile/puranindia/net-framework-and-architecture/>
- <http://www.csn.ul.ie/~caolan/pub/winresdump/winresdump/doc/pefile2.html>
- <https://en.wikipedia.org/wiki/Portable_Executable#Relocations>
- <http://www.andreybazhan.com/pe-internals.html>
- <https://www.mzrst.com>
- <https://github.com/erocarrera/pefile>
- [An In-Depth Look into the Win32 Portable Executable File Format
](https://web.archive.org/web/20120201095648/http://msdn.microsoft.com/en-us/magazine/bb985992.aspx)
- [An In-Depth Look into the Win32 Portable Executable File Format, Part 2
](https://web.archive.org/web/20120915093039/http://msdn.microsoft.com/en-us/magazine/cc301808.aspx)
- https://owasp.org/www-pdf-archive/OWASP_IL_7_DOT_NET_Reverse_Engineering.pdf