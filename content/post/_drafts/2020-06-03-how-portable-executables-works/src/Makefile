ILASM 	:= C:\Windows\Microsoft.NET\Framework64\v4.0.30319\ilasm.exe /nologo /quiet /pdb
 
DEBUG 	:= $(ILASM) /debug
RELEASE	:= $(ILASM) 

TARGETS := Merhaba.exe

default: help

all: $(TARGETS) $(BASE64_TARGETS)

clean:
	rm *.exe
	rm *.b64

.PHONY: all help default noop clean

help:		## help
# 	@grep -E '^[a-zA-Z_-]+:.*?## .*$$' $(MAKEFILE_LIST) | sort | awk 'BEGIN {FS = ":.*?## "}; {printf "\033[36m%-30s\033[0m %s\n", $$1, $$2}'


%.exe: %.il
	$(DEBUG) /output=$@ $< 

%.dll: %.il
	$(RELEASE) /dll /output=$@ $< 
	
%.b64: %.exe
	gzip -9 -c $< | base64 > $@
