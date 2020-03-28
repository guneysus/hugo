---
draft: true
title: Powershell Tip and Tricks
---


```powershell

Function Edit () {
    param(  [Parameter(Mandatory=$true)] [String[]]$files)
&"$env:EDITOR" $files
}

Function ack () {
    # ack wrapper, since searching with 'ack --csharp "<dynamic>" causes problems.
    perl "$HOME\scoop\apps\ack\current\ack-single-file" $args --ignore-directory=obj
}

$env:EDITOR='code'
Edit (ack --csharp "<dynamic>" -l | Out-GridView -PassThru) # select all files from the grid

# all selected files will be opened in VSCode
```

```powershell
Get-ChildItem  -File -Recurse *.sql | Sort-Object -Property Length -Descending | Out-GridView

```

## no deploy on saturdays

```powershell
if ([Int](Get-Date).DayOfWeek -eq 6) {
    throw "No deploy on Saturdays!";  
}

if ((Get-Date).DayOfWeek -eq 'Saturday') {
    throw "No deploy on Saturdays!";  
}
```
