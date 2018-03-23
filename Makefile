default: develop

DEVELOP := hugo --watch --theme=guneysu --baseURL=127.0.0.1 serve

develop:
	$(DEVELOP)


build: 
	@hugo --theme=guneysu
.PHONY: default develop build
