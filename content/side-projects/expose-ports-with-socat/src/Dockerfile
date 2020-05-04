FROM alpine:3.9

RUN apk add socat

USER nobody

CMD socat -dddd TCP-LISTEN:$LISTEN,reuseaddr,fork TCP:$ORIGIN_HOST:${ORIGIN_PORT}