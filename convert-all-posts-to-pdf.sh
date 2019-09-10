#!/bin/bash

source helpers.sh


function _pdf_name () {
	pdfname=$(basename $(filename-to-ext $(dirname $post) pdf))
	echo "$(dirname $1)/$pdfname"
}

for post in `ls -1 content/post/*/*.md`;
do
	_pdf_name $post
	# echo $(basename $(filename-to-ext $(dirname $post) pdf))
	# filename-without-ext $post
	# markdown-meta $post > $(filename-to-ext $post yml)
	# markdown-to-pdf $post
	rm $(filename-to-ext $post yml) || true
	
done
