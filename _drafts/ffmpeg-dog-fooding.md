---
draft: true
---

```shell

# fit video to canvas
# https://stackoverflow.com/a/35487394/1766716
ffmpeg.exe -i .\28ggAP5fj5.mp4 -vf "scale=min(iw*360/ih\,640):min(360\,ih*640/iw),pad=640:360:(640-iw)/2:(360-ih)/2"  resized.mp4 
```