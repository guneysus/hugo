---
title: "Apache Benchmark Simple Example"
date: "2017-06-17"
draft: false
---

```
docker pull jordi/ab
```

```shell
docker run --rm jordi/ab -k -c 100 -n 1000 http://www.example.com/
```