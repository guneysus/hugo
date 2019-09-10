#!/bin/bash

function filename-without-ext () {
	echo "${1%.*}"
}

function filename-to-ext () {
	echo "${1%.*}".$2
}

function markdown-meta-last-linenumber () {
	echo $(egrep -n "^[-]{3,}" $1 | head -2 | awk -F  ":" '{print $1}' | tail -1)
}

function markdown-meta () {
	cat $1  | head -$(markdown-meta-last-linenumber $1)
}

function markdown-meta () {
	cat $1  | head -$(markdown-meta-last-linenumber $1)
}

function markdown-body () {
	cat $1  | tail +$(expr $(markdown-meta-last-linenumber $1) + 1)
}

function markdown-to-pdf () {
	markdown-body $1 | pandoc -f markdown_mmd -t latex --metadata-file=$(filename-to-ext $1 yml) --toc --highlight-style=tango --strip-comments -s -o $(filename-to-ext $1 pdf)
}