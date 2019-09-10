default:

pdf:
	bash convert-all-posts-to-pdf.sh
	
clean:
	rm content/post/*/index.pdf || true
	rm content/post/*/index.en.pdf || true

serve:
	hugo server

.PHONY: default pdf clean serve