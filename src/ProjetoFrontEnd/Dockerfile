FROM node:12.7-alpine
WORKDIR src/app
COPY package.json package-lock.json ./
RUN npm install
COPY . .
RUN npm start