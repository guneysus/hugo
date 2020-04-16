#!/bin/bash
set -ex

source helpers.sh

function pdf-name () {
	pdfname="$(basename $(filename-to-ext $(dirname $1) pdf))"
	echo "$(dirname $1)/$pdfname"
}

for post in `ls -1 content/post/*/*.md`;
do	
	metafile=$(filename-to-ext $post yml)
	markdown-meta $post > $metafile
	pdf=$(pdf-name $post)
    txt="$(filename-to-ext $pdf txt)"
    epub="$(filename-to-ext $pdf epub)"
    ascii="$(filename-to-ext $pdf ascii)"

    markdown-body $post | pandoc -f markdown_mmd -t asciidoc --metadata-file=$metafile --toc --highlight-style=tango --strip-comments -s -o $ascii
    markdown-body $post | pandoc -f markdown_mmd -t epub --metadata-file=$metafile --toc --highlight-style=tango --strip-comments -s -o $epub
    markdown-body $post | pandoc -f markdown_mmd -t plain --metadata-file=$metafile --toc --highlight-style=tango --strip-comments -s -o $txt
	markdown-body $post | pandoc -f markdown_mmd -t latex --metadata-file=$metafile --toc --highlight-style=tango --strip-comments -s -o $pdf
done


