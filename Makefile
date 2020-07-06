VERSION := '0.55.2'
HUGO_SERVER := hugo-$(VERSION) server  --buildDrafts -v --debug -p 8000

default: develop

develop:
	$(HUGO_SERVER)

.PHONY: default develop