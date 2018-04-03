default: develop


DEVELOP := hugo \
			--watch serve \
			--buildDrafts \
			--buildFuture \
			--disableFastRender \
			--baseURL=127.0.0.1

develop:
	$(DEVELOP)

.PHONY: default develop
