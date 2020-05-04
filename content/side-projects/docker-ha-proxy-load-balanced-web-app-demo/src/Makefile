.PHONY: default
default: help

.PHONY: help
help:  ## Print this message.
	@awk 'BEGIN {FS = ":.*?## "} /^[a-zA-Z_-]+:.*?## / {printf "\033[36m%-30s\033[0m %s\n", $$1, $$2}' $(MAKEFILE_LIST) | sort

.PHONY: up
up:		## Docker compose run
	docker-compose up --build -d

.PHONY: down
down:  ## Docker compose run
	docker-compose down

.PHONY: test
test:	## Load test HaProxy
	locust -f ~/.locust/simple.py \
		--no-web \
		--clients=1000 \
		--hatch-rate=200 \
		--run-time=0m30s \
		--print-stats \
		--logfile=locust.log \
		--reset-stats \
		--only-summary \
		--csv-base-name=results \
		--host=http://localhost:9001

.PHONY: down_1
down_1:		## down hello 1
	@docker-compose rm -f -s -v hello_1

.PHONY: down_2
down_2:		## down hello 1
	@docker-compose rm -f -s -v hello_2

.PHONY:	down_3
down_3:		## down hello 1
	@docker-compose rm -f -s -v hello_3

.PHONY: down_4
down_4:		## down hello 1
	@docker-compose rm -f -s -v hello_4

.PHONY: down_5
down_5:		## down hello 1
	@docker-compose rm -f -s -v hello_5