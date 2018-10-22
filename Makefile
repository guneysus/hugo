default: develop

PREVIEW := hugo \
			--watch serve \
			--disableFastRender \
			--baseURL=127.0.0.1
DEVELOP := hugo \
			--watch serve \
			--buildDrafts \
			--buildFuture \
			--disableFastRender \
			--baseURL=127.0.0.1


develop:
	$(DEVELOP)

preview:
	$(PREVIEW)

.PHONY: default develop preview
