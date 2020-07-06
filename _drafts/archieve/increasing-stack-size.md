---
draft: true
---


```
EDITBIN.EXE /STACK:131072 file.exe
```

http://content.atalasoft.com/atalasoft-blog/increasing-the-size-of-your-stack-net-memory-management-part-3

https://docs.microsoft.com/en-us/cpp/build/reference/editbin-command-line?view=vs-2019

https://docs.microsoft.com/en-us/cpp/build/reference/heap?view=vs-2019

https://docs.microsoft.com/en-us/cpp/build/reference/stack?view=vs-2019

```
>Microsoft (R) COFF Binary File Editor Version 5.12.8078
Copyright (C) Microsoft Corp 1992-1998. All rights reserved.

usage: EDITBIN [options] [files]

   options:

      /BIND[:PATH=path]
      /HEAP:reserve[,commit]
      /LARGEADDRESSAWARE[:NO]
      /NOLOGO
      /REBASE[:[BASE=address][,BASEFILE][,DOWN]]
      /RELEASE
      /SECTION:name[=newname][,[[!]{cdeikomprsuw}][a{1248ptsx}]]
      /STACK:reserve[,commit]
      /SUBSYSTEM:{NATIVE|WINDOWS|CONSOLE|WINDOWSCE|POSIX}[,#[.##]]
      /SWAPRUN:{[!]CD|[!]NET}
      /VERSION:#[.#]
      /WS:[!]AGGRESSIVE
 [features/ahmed.guneysu/57988 +0 ~2 -0 !]  get-command editbin

CommandType     Name                                               Version    Source
-----------     ----                                               -------    ------
Application     editbin.exe                                        0.0.0.0    C:\masm32\bin\editbin.exe
```