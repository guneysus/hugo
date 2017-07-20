default: develop

develop:
	@hugo serve --watch --theme=paperback

publish:
	@hugo --theme=paperback

.PHONY: default develop publish

