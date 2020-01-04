default:

pdf:
	bash convert-all-posts-to-pdf.sh
	
clean:
	git clean -f
	rm content/post/*/index.pdf || true
	rm content/post/*/index.en.pdf || true
	rm tex2pdf.-* -rf || true

serve:
	hugo server --enableGitInfo -v --debug -D

.PHONY: default pdf clean serve
