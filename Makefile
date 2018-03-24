default: develop


DEVELOP := hugo \
			--watch serve \
			--destination /tmp/blog_dev \
			--buildDrafts \
			--buildFuture \
			--baseURL=127.0.0.1		

develop:
	$(DEVELOP)

.PHONY: default develop
