FROM node:21 AS build
WORKDIR /app
COPY package*.json ./
RUN npm install  --force
COPY . .
RUN npm run prod
EXPOSE 4200
CMD ["npm", "start"]

FROM nginx:alpine
WORKDIR /app


