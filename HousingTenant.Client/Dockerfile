FROM node:latest
WORKDIR /app
COPY ./public /app/public
COPY package.json /app
COPY package-lock.json /app
RUN npm install --global http-server
CMD ["npm", "start"]
