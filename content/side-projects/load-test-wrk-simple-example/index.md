---
title: "wrk Simple Example"
date: "2017-06-17"
draft: false
summary: "TODO"
---

```
docker pull williamyeh/wrk
```


```shell
docker run --rm  williamyeh/wrk  http://www.example.com/
```

```shell
docker run --rm  williamyeh/wrk https://example.com -c 300 -d 30s --latency --timeout 5s
```