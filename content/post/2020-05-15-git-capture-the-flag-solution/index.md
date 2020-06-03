---
title: "[Çözüm] GIT Capture the Flag, Git İç Yapısı ve Git Objeleri"
date: 2020-04-29T21:42:11+03:00
draft: false
slug: "odulsuz-git-ctf-yarismasi-cozum"
summary: "**Yeni ipucu eklendi**🧵 "
tags:
  - git
  - internals
  - ctf
  - how-stuff-works
---

## Giriş

Merhaba. Onbeş gün kadar önce ödülsüz tek soruluk bir GIT CTF [^git-ctf] sorusu yayınlamıştım.
Hiç kimseden yanlış dahi olsa bir cevap gelmedi.

Çözümünü yayınlıyorum.

## GIT Objeleri

> Git is a content-addressable filesystem. Great. What does that mean? It means that at the core of Git is a simple key-value data store. What this means is that you can insert any kind of content into a Git repository, for which Git will hand you back a unique key you can use later to retrieve that content. [^git-objects]

Git çekirdeği, basit bir key-value veri tabanıdır. İstediğiniz herhangi bir içeriği Git ile saklayabilirsiniz ve akabinde Git size bunu eşsiz bir Id döndürür.

Git obje veritabanı `.git/objects` klasörüdür.

Boş bir repo oluşturalım ve içinde hiçbir obje olmadığını teyit edelim.

```mintty
$ git init test-repo && cd test-repo
Initialized empty Git repository in C:/Users/guneysu/AppData/Local/Temp/test-repo/.git/

$ find .git/objects
.git/objects
.git/objects/info
.git/objects/pack

$ find .git/objects -type f ^C

$ find .git/objects -type f
```

Git veri tabanına elle bir obje oluşturalım.

```mintty

$ echo 'test content' | git hash-object -w --stdin
d670460b4b4aece5915caf5c68d12f560a9fe3e4
```

`git hash-object` komutu, verdiğiniz içeriğini git veritabanında saklandığında size vereceği benzersiz ID'yi döndürür.
`-w` parametresi ise sadece ID döndürmekle kalmaz, bu objeyi de veritanına kaydeder.
`--stdin` ile içeriğini standart inputtan alacağımızı bildirdik. Bu parametreyi vermeseydik, dosya yolunu vermemiz gerekecekti.

Yukarıdaki komutun çıktısı, 40 karakterlik bir SHA-1 hash değeridir.

Git veritabanını tekrark kontrol edelim.

```mintty
$ find .git/objects -type f
.git/objects/d6/70460b4b4aece5915caf5c68d12f560a9fe3e4
```

`git cat-file` komutu ile git objelerinin içeriğini görüntüleyebilirsiniz.

```mintty
$ git cat-file -p d670460b4b4aece5915caf5c68d12f560a9fe3e4
test content
```

GIT objeleri hakkında bu kadar bilgi şimdilik yeterli. Şimdi `git notes` komutundan bahsedelim.

## `git notes`

Git objelerini değiştirmeden, notlar ekleyip çıkarmayı sağlayan komuttur. [^git-notes]
Varsayılan olarak `refs/notes/commits` içerisinde saklanır fakat bu yol değiştirilebilir.

Yukarıdaki test repomuza bir commit yapalım.

```mintty
$ echo 'test content' > test-content.txt

$ git add test-content.txt && git commit -m 'initial commit'
[master (root-commit) 5ae0756] initial commit
 1 file changed, 1 insertion(+)`
 create mode 100644 test-content.txt

$ git show -s 5ae0756
commit 5ae0756572c1928be31044dd20b94773798cd184 (HEAD -> master)
Author: Ahmed Şeref Güneysu <no-reply@example.com>
Date:   Sat May 16 13:57:26 2020 +0300

    initial commit
```

Bu commite bir not ekleyelim:

```mintty
$ git notes add -m 'Tested-by: Ahmed Şeref <no-reply@example.com>' 5ae0756
```

`5ae0756` ID'li commit detayını tekrar gösterelim ve notların commit bilgisi ile nasıl bir arada gösterildiğini görelim.

```mintty
$ git show -s 5ae0756
commit 5ae0756572c1928be31044dd20b94773798cd184 (HEAD -> master)
Author: Ahmed Şeref Güneysu <no-reply@example.com>
Date:   Sat May 16 13:57:26 2020 +0300

    initial commit

Notes:
    Tested-by: Ahmed Şeref <no-reply@example.com>
```

## Ve Çözüm !
GIT CTF reposunu [^git-ctf-repo] klonlayalım.

```mintty
$ git clone git@github.com:guneysus/git-ctf.git
Cloning into 'git-ctf'...
remote: Enumerating objects: 2, done.
remote: Counting objects: 100% (2/2), done.
remote: Total 2 (delta 0), reused 2 (delta 0), pack-reused 0
Receiving objects: 100% (2/2), done.

$ cd git-ctf/

$ git log --abbrev-commit
commit 8ed07cc (HEAD -> master, origin/master, origin/HEAD)
Author: Ahmed Şeref Güneysu <no-reply@example.com>
Date:   Wed Apr 29 17:10:20 2020 +0300

    Empty commit
```

`8ed07cc` commitimizde herhangi bir not gözükmüyor.

Yukarıda notların `refs/notes/commits` içerisinde saklandığından bahsetmiştik.
Bu yazı yazıldığı an itibariyle git notlarının `clone` veya `fetch` ile çekmenin basit bir yolu henüz yok. [^so-clone-with-notes]

Bunun için çalıştırmamız gereken komut:

```mintty
$ git fetch origin refs/notes/*:refs/notes/*
remote: Enumerating objects: 3, done.
remote: Counting objects: 100% (3/3), done.
remote: Compressing objects: 100% (2/2), done.
remote: Total 3 (delta 0), reused 3 (delta 0), pack-reused 0
Unpacking objects: 100% (3/3), 269 bytes | 22.00 KiB/s, done.
From github.com:guneysus/git-ctf
 * [new ref]         refs/notes/commits -> refs/notes/commits
```

Notlarımızı sunucudan çektik, bakalım commit detaylarımızda bu bilgileri görebilecek miyiz?

```mintty
$ git log --abbrev-commit
commit 8ed07cc (HEAD -> master, origin/master, origin/HEAD)
Author: Ahmed Şeref Güneysu <no-reply@example.com>
Date:   Wed Apr 29 17:10:20 2020 +0300

    Empty commit

Notes:
    Flag: parchment
```

## Evet, bayrağımızı bulduk: **`parchment`** 🎊

Git reposunun git notlarını da içeren halini aşağıda [Resources](#ref:resources) kısmından da indirebilirsiniz.

<p><a href="https://commons.wikimedia.org/wiki/File:Parchment.png#/media/File:Parchment.png"><img src="https://upload.wikimedia.org/wikipedia/commons/4/48/Parchment.png" alt="Parchment.png"></a><br>By <a href="//commons.wikimedia.org/wiki/User:IgniX" title="User:IgniX">IgniX</a> - <span class="int-own-work" lang="en">Own work</span>, <a href="https://creativecommons.org/licenses/by-sa/3.0" title="Creative Commons Attribution-Share Alike 3.0">CC BY-SA 3.0</a>, <a href="https://commons.wikimedia.org/w/index.php?curid=19412303">Link</a></p>

[^git-ctf]: ["GIT Capture the Flag! 🏴"](/post/odulsuz-git-ctf-yarismasi)
[^git-objects]: [Git Internals - Git Objects](https://git-scm.com/book/en/v2/Git-Internals-Git-Objects)
[^git-notes]: [Git Notes](https://git-scm.com/docs/git-notes)
[^git-ctf-repo]: [GIT CTF Repo](https://github.com/guneysus/git-ctf)
[^so-clone-with-notes]: [Fetch git notes when cloning](https://stackoverflow.com/a/37952282/1766716)