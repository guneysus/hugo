#!/bin/bash


function extract-css-classes() {
  # https://superuser.com/a/968316/196369
  grep -Eoih class\=\"[^\"]*\" **/**/*.html | sed -e 's/"//g' -e 's/class=//g' | tr " " "\n" | sort -u
}


function main() {
  echo "["
  for class in `extract-css-classes`; do
    echo "'.$class', "
  done
  echo "]"


}

main

