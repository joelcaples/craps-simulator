# pull the base image
FROM node:alpine

# set the working direction
WORKDIR /app

EXPOSE 3000

# add `/app/node_modules/.bin` to $PATH
ENV PATH /app/node_modules/.bin:$PATH

# install app dependencies
COPY craps-simulator.react/package.json ./
COPY craps-simulator.react/package-lock.json ./

RUN npm install

# add app
COPY craps-simulator.react/. ./

# start app
CMD ["npm", "start"]