#!/bin/bash

set -ex

QUALITIES="45 85"
THUMB_WIDTHS="220 160 127"
WIDTHS="1800 700 645 620 300"

# convert image.jpg -quality 80 new.jpg
# convert image.jpg -quality 80 new.jpg

# BASENAME="image"
# ORIGINAL=image.jpg
# for q in $QUALITIES; do
    # for w in $THUMB_WIDTHS; do
        # FOLDER="${w}px"
        # mkdir -p $FOLDER
        # RESIZED="${FOLDER}/${BASENAME}-${w}px-q${q}.jpg"
        # magick $ORIGINAL -quality ${q} -resize ${w} ${RESIZED}
    # done
# done

85
# for w in $WIDTHS; do
    # FOLDER="${w}px"
    # mkdir -p $FOLDER
    # RESIZED="${FOLDER}/${BASENAME}-${w}px-q${q}.jpg"
    # magick $ORIGINAL -quality 85 -resize ${w} ${RESIZED}
# done

function process () {
	fullpath=$1
	quality=$2
	width=$3
	
	path=${fullpath%/*}
	filename=$(basename $fullpath)
	filename-without-ext="${fullpath%.*}"
	
}