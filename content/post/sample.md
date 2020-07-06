---
draft: true
title: "sample"
summary: "**Lorem Ipsum**, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Emphasis, aka italics, with *asterisks* or _underscores_.
date: 2020-04-01T19:29:06+03:00

Strong emphasis, aka bold, with **asterisks** or __underscores__.

Combined emphasis with **asterisks and _underscores_**.

Strikethrough uses two tildes. ~~Scratch this.~~"

tags:
    - lorem
    - ipsum
    - di amet
---

## nereden gelir

1500'lerden beri kullanılmakta olan standard Lorem Ipsum metinleri ilgilenenler için yeniden üretilmiştir. Çiçero tarafından yazılan 1.10.32 ve 1.10.33 bölümleri de 1914 H. Rackham çevirisinden alınan İngilizce sürümleri eşliğinde özgün biçiminden yeniden üretilmiştir.

## task list

- [ ] task1
- [x] task2
- [ ] task3

## smartypants

- "double quote"
- 'single quote'
- smart dash single dash - Ahmed
- smart dash double dash -- Ahmed
- smart dash triple dash --- Ahmed
- fractions 1/2, 2/3

### syntax hightlight

```powershell
Get-ChildItem  -File -Recurse *.sql | Sort-Object -Property Length -Descending | Out-GridView

```

### no deploy on saturdays

```powershell
if ([Int](Get-Date).DayOfWeek -eq 6) {
    throw "No deploy on Saturdays!";  
}

if ((Get-Date).DayOfWeek -eq 'Saturday') {
    throw "No deploy on Saturdays!";  
}
```

### C# Reflection with Powershell

```powershell
100.0 | Get-Member -MemberType Method
```


## footnotes
This is a footnote.[^1]

[^1]: the footnote text.

## definition lists

Cat
: Fluffy animal everyone likes

Internet
: Vector of transmission for pictures of cats

---

