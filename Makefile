default: develop

DEVELOP := hugo --watch --theme=guneysu serve

develop:
	$(DEVELOP)

.PHONY: default develop 

