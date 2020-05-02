Tornado Simple File Upload
==========================

## Running
```
docker-compose up -d
```


## Testing
```
http -f POST :8000/ file@requirements.txt
```

```
HTTP/1.1 200 OK
Content-Length: 55
Content-Type: application/json; charset=UTF-8
Date: Sat, 02 May 2020 13:58:55 GMT
Server: TornadoServer/4.5.1

{
    "files": [
        "9313dedf-da00-4ce7-bf74-43448e53e8b1.txt"
    ]
}
```

<http://localhost:8000/uploads/9313dedf-da00-4ce7-bf74-43448e53e8b1.txt>
