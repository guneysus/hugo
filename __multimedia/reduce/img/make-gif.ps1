ffmpeg -f image2 -y -framerate 1 -i reduce-illustration-%d.jpg output.mp4

ffmpeg -f image2 -y -framerate 1 -i reduce-illustration-%d.png reduce-illustration.webm
ffmpeg -f image2 -y -framerate 1 -i reduce-illustration-%d.png reduce-illustration.mp4
ffmpeg -f image2 -y -framerate 1 -i reduce-illustration-%d.png reduce-illustration.mkv

# rm list.txt

# 1..3 | % { echo "file 'reduce-illustration.webm'" >> list.txt }

ffmpeg -y -f concat  -i list-webm.txt -c copy reduce-loop.webm	
# ffmpeg -y -f concat  -i list-mp4.txt -c copy reduce-loop.mp4
ffmpeg -y -f concat  -i list-mkv.txt -c copy reduce-loop.mkv


# ffmpeg -i reduce-loop.mkv -c:v libx264 -profile:v high -preset slow reduce-loop.mp4

# ffmpeg -i reduce-loop.mp4 -c:v 'libx264 -profile:v high -preset slow -b:v 1500k -maxrate 2500k -bufsize 5000k -threads 0 -codec:a aac -b:a 128k reduce-loop.mp4


# ffmpeg -y -i reduce-loop.webm -vf scale=1920x1080:flags=lanczos -c:v libx264 -preset slow -crf 21 outputfin.mp4

ffmpeg -y -filter_complex "[0:v] palettegen" -i .\reduce-illustration.mp4 -f gif reduce-loop.gif