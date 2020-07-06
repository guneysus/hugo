VERSION := '0.55.2'
HUGO_SERVER := hugo-$(VERSION) server --enableGitInfo -v --debug -p 1314

default: serve

clean:
	git clean -f
	rm content/post/*/index.pdf || true
	rm content/post/*/index.en.pdf || true
	rm tex2pdf.-* -rf || true

serve:
	$(HUGO_SERVER)

deploy:
	hugo deploy --target=s3 --dryRun --debug

.PHONY: default clean serve