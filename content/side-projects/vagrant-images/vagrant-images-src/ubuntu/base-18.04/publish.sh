#!/bin/bash
vagrant cloud publish \
    guneysu-ubuntu-base-18.04 1.0.0 virtualbox \
    guneysu-ubuntu-base-18.04.box \
    -d "A really cool box to download and use" \
    --version-description "A cool version" \
    --release \
    --short-description "Download me!"
