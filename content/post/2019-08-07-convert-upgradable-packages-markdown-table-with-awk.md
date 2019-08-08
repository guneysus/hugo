---
title: "Convert Upgradable Packages Markdown Table With Awk"
date: 2019-08-07T19:30:05+03:00
description: 
summary: bla bla bla
tags:
    - linux
    - shell
    - devops
slug: awk-ile-upgrade-edilecek-paket-listesinin-markdown-tablosuna-donusturmek
keywords:
    - awk
  
draft: true
---


{{< highlight awk "linenos=table,hl_lines=,linenostart=1" >}}
#!/bin/awk -f


BEGIN {
FS=" ";
OFS=" | ";
RS="\n"

print "id | package | repo | current | new"
print "---|---------|------|---------| ----"
}
{
    split($1, package_arr, "/")
    package=package_arr[1]
    repo=package_arr[2]
    pattern="]"
	gsub(pattern, "", $6)
	print NR, package, repo, $2, $6
}


{{< / highlight >}}


usage:

```shell
$ ssh gitlab3root "apt update >/dev/null 2>&1 && apt list --upgradable" 2>/dev/null | egrep -v 'Listing' | awk -f parse-apt-upgradable.awk
```


convert to html

```bash
python -m markdown

```