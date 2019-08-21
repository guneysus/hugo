#!/bin/bash

docker run --rm -v $(pwd)/content/static:/data -it guneysu/imagemagick:latest sh -c "bash generate-webp.sh"