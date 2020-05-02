---
title: "File Upload with Tornado"
date: "2017-06-17"
draft: false
---


<div class="f6">

  {{% attachment lang="python" path="src/app/__main__.py" title="Tornado Application" name="__main__.py" /%}}

  {{% attachment lang="yml" path="src/docker-compose.yml" title="Docker Compose" name="docker-compose.yml" /%}}

  {{% attachment lang="Dockerfile" path="src/Dockerfile" title="Dockerfile" name="docker-compose.yml" /%}}

  {{% attachment lang="html" path="src/app/upload.html" title="Upload Page" name="upload.html" /%}}

  {{% attachment lang="txt" path="src/requirements.txt" title="Requirements" name="requirements.txt" /%}}

  {{% attachment lang="Makefile" path="src/Makefile" title="Makefile" name="Makefile" /%}}
</div>


## Running
```shell
docker-compose up -d
```


## Testing

```shell
http -f POST :8000/ file@requirements.txt
```

```
HTTP/1.1 200 OK
Content-Length: 215
Content-Type: application/json; charset=UTF-8
Date: Sat, 02 May 2020 14:36:36 GMT
Server: TornadoServer/4.5.1

{
    "files": [
        "6936cd27-01dc-4af6-adf9-970ad168ed6b.txt",
        "1c7052d7-0e29-4eb4-a914-f58d78289add.txt"
    ],
    "urls": [
        "/uploads/6936cd27-01dc-4af6-adf9-970ad168ed6b.txt",
        "/uploads/1c7052d7-0e29-4eb4-a914-f58d78289add.txt"
    ]
}
```