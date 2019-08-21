#!/bin/bash

# set -ex

pwd

function process-image () {
	
	fullpath=$1
	quality=${2:-85}
	height=$3
	
	if [ -z "$height" ]; 
	then
		echo Define height
		return 1
	fi

	folder="${height}px"
	mkdir -p $folder

	path="${fullpath%/*}"
	filename="$(basename $fullpath)"
	filename_without_ext="${fullpath%.*}"
	
	# echo $fullpath "${folder}/${filename_without_ext}-${height}px-q${quality}.jpg"
	# echo $fullpath "${folder}/${filename_without_ext}-${height}px-q${quality}.webp"

	# magick $fullpath -quality ${quality} -resize x${height} "${folder}/${filename_without_ext}-${height}px-q${quality}.jpg"
	
	png_fullpath="${folder}/${filename_without_ext}-${height}px-q${quality}.png"
	webp_fullpath="${folder}/${filename_without_ext}-${height}px-q${quality}.webp"

	magick $fullpath \
		-depth 8 \
		-quality ${quality} \
		-resize x${height} \
		-define png:compression-filter=5 \
		-define png:compression-strategy=1 \
		-define png:compression-level=9 \
		$png_fullpath
	
  	width=$(identify -format %w $png_fullpath)
	
	convert -background '#0008' -fill white -gravity center -size ${width}x30 \
          caption:"${width} x ${height}" \
          $png_fullpath +swap -gravity south -composite  $png_fullpath

	return 0

	magick $fullpath \
			-depth 8 \
			-quality ${quality} \
			-resize x${height} \
			-define png:compression-filter=5 \
			-define png:compression-strategy=1 \
			-define png:compression-level=9 \
			$webp_fullpath		

	# echo $path
	# echo $filename
	# echo $filename_without_ext
	# echo $quality
	# echo $height
}

for png in `ls *.png`; do
	basename=${png%.*}
	webp=${basename}.webp
	process-image $png 85 220 # $webp
	process-image $png 45 220 # $webp

	process-image $png 85 160 # $webp
	process-image $png 45 160 # $webp

	process-image $png 85 127 # $webp
	process-image $png 45 127 # $webp
done
