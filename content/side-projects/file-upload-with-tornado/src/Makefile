default: run

build:
	@docker-compose build

run: build
	@docker-compose up

test:
	@http -f POST :8000/upload file@requirements.txt file@requirements.txt

down:
	@docker-compose down
	
develop:
	@docker-compose up --build

.PHONY: default build run test down develop