
# build deps
FROM node:16.0.0 as builder

RUN mkdir app
WORKDIR app
COPY . ./

ENV PATH ./node_modules/.bin:$PATH

RUN npm install
RUN npm run build


# prepare server
FROM node:16.0.0

RUN mkdir /usr/app
WORKDIR /usr/app
RUN npm install -g serve --silent
COPY --from=builder /app/build .

EXPOSE 4000
CMD [ "serve", "-s", ".", "-p", "4000" ]