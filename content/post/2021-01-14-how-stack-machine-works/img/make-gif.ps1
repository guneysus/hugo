
ls *.png | % { magick $_.Name ($_.BaseName+".jpg") }
ffmpeg -f image2 -y -framerate 1 -i %d.jpg output.gif
