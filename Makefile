default: develop

DEVELOP := hugo \
			--watch \
			--baseURL=127.0.0.1 serve \
			--buildDrafts \
			--buildExpired \
			--buildFuture \
			--enableGitInfo \
			--i18n-warnings \
			--destination /tmp/blog_dev

develop:
	$(DEVELOP)

.PHONY: default develop
