#!/bin/bash

set -ex

TEST_TIMESTAMP=$(date +%Y-%m-%d_%H%M)

date

locust -f simple-locustfile.py \
    --no-web \
    --clients=1000 \
    --hatch-rate=500 \
    --run-time=0m30s \
    --print-stats \
    --logfile=logs/$TEST_TIMESTAMP.log \
    --reset-stats \
    --csv-base-name=results/$TEST_TIMESTAMP \
    --only-summary \
    --host=http://localhost:2016

    # --host=https://dddv93lgeegfh.cloudfront.net \
