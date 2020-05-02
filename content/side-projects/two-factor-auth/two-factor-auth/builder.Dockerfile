FROM guneysu/roller:2.7
VOLUME ["/whl"]
WORKDIR /whl
RUN apk add -U --no-cache --virtual .build-deps \
  jpeg-dev zlib-dev libwebp-dev freetype-dev openjpeg-dev \
  libwebp-dev
CMD pip wheel -r requirements.txt  
