#!/bin/bash

source helpers.sh
set -ex


function _pdf_name () {
	pdfname=$(basename $(filename-to-ext $(dirname $post) pdf))
	echo "$(dirname $1)/$pdfname"
}

for post in `ls -1 content/post/*/*.md`;
do	
	markdown-meta $post > $(filename-to-ext $post yml)
	markdown-to-pdf $post $(_pdf_name $post) || true
	# rm $(filename-to-ext $post yml) || true
	break
done
