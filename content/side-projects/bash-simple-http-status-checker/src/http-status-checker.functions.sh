#!/bin/bash

function http-status-check {
	# export TERM=xterm-color
	# export GREP_OPTIONS='--color=auto' GREP_COLOR='1;32'
	# export CLICOLOR=1
	# export LSCOLORS=ExFxCxDxBxegedabagacad

	NORMAL=`echo -e '\033[0m'`
	RED=`echo -e '\033[31m'`
	GREEN=`echo -e '\033[0;32m'`
	LGREEN=`echo -e '\033[1;32m'`
	BLUE=`echo -e '\033[0;34m'`
	LBLUE=`echo -e '\033[1;34m'`
	YELLOW=`echo -e '\033[0;33m'`


    # uri $1
	URL=$1
    STATUS="$(curl --connect-timeout 1 -sL -w "%{http_code}\\n" "${URL}" -o /dev/null)"
    if [[ $STATUS -ne 200 ]]
        then
            echo " ${YELLOW} $STATUS ${RED} $URL${NORMAL} "
        else
            echo " ${YELLOW} $STATUS ${BLUE} $URL ${NORMAL}"
    fi
}

function get-links () {
	wget $1 -O - 2>/dev/null | grep -oP 'href="\Khttp:.+?"' | sed 's/"//' | sort
}

function http-check-bulk () {
	command=$1
	
	while read p; do
		http-status-check $p
	done </dev/stdin
}
