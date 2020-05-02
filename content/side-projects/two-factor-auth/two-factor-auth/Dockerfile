FROM guneysu/python:2.7
RUN apk add pcre=='8.43-r0' -U
ADD uwsgi /usr/local/sbin/
ADD whl /tmp
RUN pip install /tmp/*.whl

ADD app /app
ADD uwsgi.ini /

WORKDIR /

RUN apk add libjpeg openjpeg zlib freetype libwebp
CMD uwsgi --ini uwsgi.ini
