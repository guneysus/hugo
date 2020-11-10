```
Invoke-RestMethod httpbin.org/ip | Format-Table
Invoke-RestMethod httpbin.org/ip | Format-List
Invoke-RestMethod httpbin.org/ip | format-bytearray
(Invoke-RestMethod httpbin.org/ip).origin

$myip=(Invoke-RestMethod httpbin.org/ip).origin

Invoke-RestMethod httpbin.org/ip | ConvertTo-Html
Invoke-RestMethod httpbin.org/ip | ConvertTo-Csv

 Invoke-RestMethod httpbin.org/ip | ConvertTo-Csv
 
 Invoke-RestMethod -Uri https://blogs.msdn.microsoft.com/powershell/feed/ | Format-Table -Property Title, pubDate
 
 
Invoke-WebRequest httpbin.org/post -Method Post  -InFile .\_data\example1.json | Select-Object Content | Select-String -

 (Invoke-WebRequest httpbin.org/post -Method Post -InFile .\_data\example1.json | Select-Object content).Content | ConvertFrom-Json
 
 
Get-Date | Select-Object -Property * | ConvertTo-Json

Get-Date | Select-Object -Property * | ConvertTo-Json | ConvertFrom-Json

Get-Date | Select-Object -Property * | ConvertTo-Json -Compress


 'Hello World' | Format-Hex


 Get-Host | Format-Table -AutoSize

 Get-Process | Sort-Object -Property basepriority | Format-Table -GroupBy basepriority -Wrap
 

 Get-Process  | select -First 10



# https://docs.microsoft.com/en-us/previous-versions/powershell/module/Microsoft.PowerShell.Management/Get-Process?view=powershell-5.0

 Get-Process | Select -First 10 | ConvertTo-Json

 Get-Process | Select -First 1 | Select -Property * | Format-Table


 Get-Process | Select -First 5 | Select -Property id, name, cpu, responding, threads, processName | Format-Table


 Get-Process notepa*

 Get-Process notepa* | select -Property Id | Debug-Process

```


```

Function CreateWebServer () {
    # enter this URL to reach PowerShell?s web server
    $url = 'http://localhost:8080/'


    # https://stackoverflow.com/a/1789948/1766716
    [console]::TreatControlCAsInput = $true


    # HTML content for some URLs entered by the user
    $htmlcontents = @{
      'GET /'  =  '<html><building>Here is PowerShell</building></html>'
      'GET /services'  =  Get-Service | ConvertTo-Html

    }

    # start web server
    $listener = New-Object System.Net.HttpListener
    $listener.Prefixes.Add($url)
    $listener.Start()

    echo "webserver started: $url" 

    try
    {
      while ($listener.IsListening) {  

        # process received request
        $context = $listener.GetContext()
        $Request = $context.Request
        $Response = $context.Response

        $received = '{0} {1}' -f $Request.httpmethod, $Request.url.localpath
    
        # is there HTML content for this URL?
        $html = $htmlcontents[$received]
        if ($html -eq $null) {
          $Response.statuscode = 404
          $html = 'Oops, the page is not available!'
        } 
    
        # return the HTML to the caller
        $buffer = [Text.Encoding]::UTF8.GetBytes($html)
        $Response.ContentLength64 = $buffer.length
        $Response.OutputStream.Write($buffer, 0, $buffer.length)
    
        $Response.Close()
      }
    }
    catch {
        $listener.Stop()
    }
    finally
    {
      $listener.Stop()
    }
}
```


```
[System.String].GetMembers() | Select -First 5 | Format-Table | ConvertTo-Html 

[System.String].GetMembers() | Select -First 5 | Format-Table | ConvertTo-Html | Out-File -FilePath system.string.html

[System.String].GetMembers() | Select -First 5 | Select-Object name, module, IsGenericMethod, IsGenericMethodDefinition, ContainsGenericParameters, IsPublic, IsPrivate, IsStatic | Format-Table | ConvertTo-Html | Out-File -FilePath system.string.html

[System.String].GetMembers() | Select-Object name, module, IsGenericMethod, IsGenericMethodDefinition, ContainsGenericParameters, IsPublic, IsPrivate, IsStatic | Format-Table | ConvertTo-Html | Out-File -FilePath system.string.html


```

```
Function Compile () {
    # https://www.sharepointdiary.com/2013/07/how-to-run-csharp-code-from-powershell.html
    # usage: [Tk]::Dec([Tk]::Enc("foo","p@ass"), "p@ass")

$Assembly = @();

$SourceCode = @"

using System;
using System.Text;
using System.Linq;

public static class Tk {
    public static string Enc(string s, string p) {
        return Convert.ToBase64String(Encoding.UTF8.GetBytes(s).Select((b, i) => (byte)(b ^ Encoding.UTF8.GetBytes(p)[i % p.Length])).ToArray());
    }

    public static string Dec(string e, string p)
    {
        var key = Encoding.UTF8.GetBytes(p);
        return Encoding.UTF8.GetString(Convert.FromBase64String(e).Select((b, i) => (byte)(b ^ key[i % key.Length])).ToArray());
    }
}
"@

   Add-Type -ReferencedAssemblies $Assembly -TypeDefinition $SourceCode -Language CSharp
}
```

```
import-module "C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.Windows.Forms.dll"
[System.Windows.Forms.MessageBox]::Show("Hello")
[System.Windows.Forms.Form]::new().Show()



 $appContext=[System.Windows.Forms.ApplicationContext]::new()
 $appContext.MainForm = [System.Windows.Forms.Form]::new()
  $appContext.MainForm.Show()
  
  
# https://stackoverflow.com/a/37468429/1766716
# $bytes = [System.IO.File]::ReadAllBytes($storageAssemblyPath)
# [System.Reflection.Assembly]::Load($bytes)


Get-Process | Out-GridView

Get-Process notepad2  | Select @{ Name = "UserProcessorTime_Ticks"; Expression = { $_.UserProcessorTime.Ticks }}
  
  
# https://docs.microsoft.com/en-us/powershell/module/microsoft.powershell.core/new-module?view=powershell-6
New-Module -ScriptBlock {function Hello {"Hello!"}} -name _ | Import-Module


$m = New-Module -ScriptBlock {function Hello ($name) {"Hello, $name"}; function Goodbye ($name) {"Goodbye, $name"}} -AsCustomObject
$m
$m | Get-Member


 Function Get-Processes_Top10_ByCpu () {
     # from:https://stackoverflow.com/a/22819444/1766716
     # Get-Counter '\Process(*)\% Processor Time' `
     #     | Select-Object -ExpandProperty countersamples `
     #     | Select-Object -Property instancename, cookedvalue `
     #     | Sort-Object -Property cookedvalue -Descending | Select-Object -First 10 `
     #     | ft InstanceName,@{L='CPU';E={($_.Cookedvalue/100).toString('P')}} -AutoSize

     Invoke-Expression(_.FromBase64String('R2V0LUNvdW50ZXIgJ1xQcm9jZXNzKCopXCUgUHJvY2Vzc29yIFRpbWUnIGAgfCBTZWxlY3QtT2Jq ZWN0IC1FeHBhbmRQcm9wZXJ0eSBjb3VudGVyc2FtcGxlcyBgIHwgU2VsZWN0LU9iamVjdCAtUHJv cGVydHkgaW5zdGFuY2VuYW1lLCBjb29rZWR2YWx1ZSBgIHwgU29ydC1PYmplY3QgLVByb3BlcnR5 IGNvb2tlZHZhbHVlIC1EZXNjZW5kaW5nIHwgU2VsZWN0LU9iamVjdCAtRmlyc3QgMTAgYCB8IGZ0 IEluc3RhbmNlTmFtZSxAe0w9J0NQVSc7RT17KCRfLkNvb2tlZHZhbHVlLzEwMCkudG9TdHJpbmco J1AnKX19IC1BdXRvU2l6ZQ=='))
 }


 Function Get-IIS-Version () {
     # Get-ItemProperty -Path registry::HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\InetStp\ | Select @{ n="version"; e={ "$($_.MajorVersion).$($_.MinorVersion)" }  }
     Invoke-Expression(_.FromBase64String('R2V0LUl0ZW1Qcm9wZXJ0eSAtUGF0aCByZWdpc3RyeTo6SEtFWV9MT0NBTF9NQUNISU5FXFNPRlRXQVJFXE1pY3Jvc29mdFxJbmV0U3RwXCB8IFNlbGVjdCBAeyBuPSJ2ZXJzaW9uIjsgZT17ICIkKCRfLk1ham9yVmVyc2lvbikuJCgkXy5NaW5vclZlcnNpb24pIiB9ICB9'))
 }
   
```

https://en.wikipedia.org/wiki/List_of_file_signatures
```powershell
Get-Content .\sample.zip -Encoding Byte -First 4 | Format-Hex
50
4B
07
08

# powershell 5
(Get-Content .\extracted_at_0x62.zip -Encoding Byte -First 4 | format-hex) -join " "
50 4B 07 08

# powershell 7
Get-Content .\extracted_at_0x62.zip -AsByteStream -First 4 | format-hex
   Label: Byte (System.Byte) <0141FBD1>

          Offset Bytes                                           Ascii
                 00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
          ------ ----------------------------------------------- -----
0000000000000000 50 4B 07 08                                     PK??

Get-Content .\extracted_at_0x62.zip -AsByteStream -First 16 | Convert-Hex | Out-String -NoNewline
504B070844AC53241F00000013000000
```


## show wpf window with powershell
https://blog.adamfurmanek.pl/2016/03/19/executing-c-code-using-powershell-script/

```powershell
Add-Type -AssemblyName PresentationFramework
[xml]$xaml =
@"
<Window
  xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
  xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
  Title="Window1" Height="300" Width="408">
    <Grid>
      <Button x:Name="button1"
                Width="75"
                Height="23"
                Canvas.Left="118"
                Canvas.Top="10"
                Content="Click Here" />
    </Grid>
</Window>
"@
Clear-Host
$reader=(New-Object System.Xml.XmlNodeReader $xaml)
$target=[Windows.Markup.XamlReader]::Load($reader)
$control=$target.FindName("button1")
$eventMethod=$control.add_click
$eventMethod.Invoke({$target.Title="Hello $((Get-Date).ToString('G'))"})
$target.ShowDialog() | out-null 
```

```powershell
powershell -sta -nop -window Hidden -Command "import-module 'C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.Windows.Forms.dll'; [System.Windows.Forms.MessageBox]::Show('alert(1)')"
```

```
1..128 | % { write ( ($_ * 32) | ConvertTo-Hex) } | Set-Clipboard
20
40
60
80
A0
C0
E0
100
120
140
160
180
1A0
1C0
1E0
200
```

```powershell
$google = (Invoke-WebRequest https://www.google.com)
$google.InputFields | where name -eq "q"

$search = ($google.Forms | where Action -eq "/search")

$google.Links | select href
```


```powershell
(Get-NetIPAddress | Where-Object AddressFamily -eq "IPv4" | where  InterfaceAlias -eq "Wi-Fi" | Select-Object IPAddress).IPAddress
```

delete merged branches
```powershell
git branch --merged master  | % { git branch -d $($_.Trim('+', ' ')) }
```


```powershell
ls -Directory | % { git -C $_ remote -v }

ls -Directory | % { echo "$(git -C $_ branch) $_" }

ls -Directory | % { git -C $_ checkout master }

```