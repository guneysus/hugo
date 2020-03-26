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

