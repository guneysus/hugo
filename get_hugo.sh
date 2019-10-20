#/bin/bash
set -ex

VERSION="$(cat HUGO_VERSION)"

DEB_URL="https://github.com/gohugoio/hugo/releases/download/v${VERSION}/hugo_extended_${VERSION}_Linux-64bit.deb"

wget ${DEB_URL} -O hugo.deb
