default: run

run:
	@docker-compose -p image-proxy up -d --build

reload:
	@docker exec -it imageproxy_backend_1 nginx -s reload

test:
	@xdg-open http://localhost:8000/i/hurriyet/90/590x0/58314cb918c77327e4ba0295.jpg

test2:
	@http http://localhost:8000/i/hurriyet/90/590x0/58314cb918c77327e4ba0295.jpg Host:i.hurimg.com
down:
	@docker-compose -p image-proxy down

.PHONY: default run reload test down