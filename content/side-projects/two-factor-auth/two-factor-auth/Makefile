default:

build:
	@docker-compose up --build builder
	@docker-compose build

run: build
	@docker-compose up --build app
		
.PHONY: default build run