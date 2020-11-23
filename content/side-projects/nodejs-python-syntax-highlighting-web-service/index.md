---
title: "Syntax Highlighter APIs with Nodejs and Python"
date: "2017-06-17"
draft: false
summary: "TODO"
---

# Syntax highligter


Just a micro web service for syntax highlighting.

For now it is implemented with `node.js` and `http://highlightjs.org`.

Since the concept is **micro service**, It would be implemented with *python* and *pigments* or another stack.

## How to run

For the impatients:

```
$ container_id=$(docker run -it -d -t guneysu/syntax-highlighter:latest)
$ container_ip=$(docker inspect --format '{{ .NetworkSettings.IPAddress }}' $container_id)
$ xdg-open http://$container_ip:8000
```

I use `Makefile`


```
$ make build run open # expilicitly
$ make 				  # for the impatients
```

```
PORT := 8000
IP_CMD := docker inspect --format '{{ .NetworkSettings.IPAddress }}' $(CONTAINER)
IP = $(shell $(IP_CMD))
CONTAINER := syntax-highlighter
all: build run open

build:
	docker build -t guneysu/syntax-highlighter:latest .

run:
	docker run -d -it --name=$(CONTAINER) -t guneysu/syntax-highlighter:latest

open:
	xdg-open http://$(IP):$(PORT)


.PHONY: all build run open 
```