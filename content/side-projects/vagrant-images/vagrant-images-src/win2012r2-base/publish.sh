#!/bin/bash
vagrant cloud publish \
    guneysu/win2012r2-base 1.0.1 virtualbox \
    guneysu-win2012r2-base \
    -d "A really cool box to download and use" \
    --version-description "A cool version" \
    --release \
    --short-description "Download me!"
