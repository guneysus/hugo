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

## pretty print path

```powershell
$env:PATH.Replace(';', [System.Environment]::NewLine)
```

## C# Reflection with Powershell

```powershell
100.0 | Get-Member -MemberType Method
```

```
TypeName: System.Double

Name        MemberType Definition
----        ---------- ----------
CompareTo   Method     int CompareTo(System.Object value), int CompareTo(double value), int IComparable.CompareTo(System.Object obj), int IComparable[double].CompareTo(double other)
Equals      Method     bool Equals(System.Object obj), bool Equals(double obj), bool IEquatable[double].Equals(double other)
GetHashCode Method     int GetHashCode()
GetType     Method     type GetType()
GetTypeCode Method     System.TypeCode GetTypeCode(), System.TypeCode IConvertible.GetTypeCode()
ToBoolean   Method     bool IConvertible.ToBoolean(System.IFormatProvider provider)
ToByte      Method     byte IConvertible.ToByte(System.IFormatProvider provider)
ToChar      Method     char IConvertible.ToChar(System.IFormatProvider provider)
ToDateTime  Method     datetime IConvertible.ToDateTime(System.IFormatProvider provider)
ToDecimal   Method     decimal IConvertible.ToDecimal(System.IFormatProvider provider)
ToDouble    Method     double IConvertible.ToDouble(System.IFormatProvider provider)
ToInt16     Method     int16 IConvertible.ToInt16(System.IFormatProvider provider)
ToInt32     Method     int IConvertible.ToInt32(System.IFormatProvider provider)
ToInt64     Method     long IConvertible.ToInt64(System.IFormatProvider provider)
ToSByte     Method     sbyte IConvertible.ToSByte(System.IFormatProvider provider)
ToSingle    Method     float IConvertible.ToSingle(System.IFormatProvider provider)
ToString    Method     string ToString(), string ToString(string format), string ToString(System.IFormatProvider provider), string ToString(string format, System.IFormatProvider provider), string IFormattable.ToString(string format,...
ToType      Method     System.Object IConvertible.ToType(type conversionType, System.IFormatProvider provider)
ToUInt16    Method     uint16 IConvertible.ToUInt16(System.IFormatProvider provider)
ToUInt32    Method     uint32 IConvertible.ToUInt32(System.IFormatProvider provider)
ToUInt64    Method     uint64 IConvertible.ToUInt64(System.IFormatProvider provider)
```
