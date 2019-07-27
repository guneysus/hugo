default: 

PREVIEW := hugo \
			--watch serve \
			--disableFastRender \
			--baseURL=127.0.0.1


DEVELOP := hugo \
			--theme guneysu-blog \
			--watch serve \
			--buildFuture \
			--disableFastRender \
			--baseURL=127.0.0.1
			# --buildDrafts \


dev:
	$(DEVELOP)

preview:
	$(PREVIEW)

.PHONY: default dev preview
