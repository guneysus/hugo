#!/usr/bin/env bash

STYLES="
monokai
manni
rrt
perldoc
borland
colorful
default
murphy
vs
trac
tango
fruity
autumn
bw
emacs
vim
pastie
friendly
native
"
THEME=paperbackcustom

for S in $STYLES
do
    hugo gen chromastyles --style=$S > themes/$THEME/static/css/pygments/$S.css
done

