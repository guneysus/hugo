FROM node:8
WORKDIR /usr/src/app
COPY package*.json ./

RUN npm install
COPY . .

CMD [ "node_modules/.bin/mocha", "--timeout", "25000", "--colors", "--reporter", "mocha-jenkins-reporter"]