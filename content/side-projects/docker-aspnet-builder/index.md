---
title: "Docker ASP.Net Builder"
date: "2017-06-17"
draft: false
summary: "TODO"
---

```Dockerfile
FROM mcr.microsoft.com/dotnet/core/sdk:2.2.105 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Debug --runtime alpine-x64 -o out


FROM mcr.microsoft.com/dotnet/core/runtime-deps:2.2-alpine
ADD out /app/
WORKDIR /app

ENV ASPNETCORE_ENVIRONMENT Development
ENV ASPNETCORE_URLS http://+:80

CMD ["/app/GM-Product-Service"]
```
