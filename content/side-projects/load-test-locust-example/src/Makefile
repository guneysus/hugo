default: test

test:
	locust -f simple-locustfile.py \
		--no-web \
		--clients=10000 \
		--hatch-rate=5000 \
		--run-time=5m0s \
		--print-stats \
		--logfile=locust.log \
		--reset-stats \
		--only-summary \
		--csv-base-name=results \
		--host=http://example.com


.PHONY: default test