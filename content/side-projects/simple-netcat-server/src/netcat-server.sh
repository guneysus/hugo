#!/usr/bin/env bash
PORT=8000
while true ; do nc -l $PORT  < index.html ; done
