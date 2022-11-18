FROM node:18-alpine as development
RUN npm i -g pnpm

WORKDIR /usr/src/app
COPY package.json pnpm-lock.yaml ./
RUN pnpm install
COPY . .
RUN pnpm run build

FROM node:18-alpine as production
RUN npm i -g pnpm

ENV REDIS_HOST=ad-service-redis
ENV REDIS_PORT=6380
ENV BRIANS_AD_SERVICE_URL=http://brians-ad-service/

WORKDIR /usr/src/app
COPY package.json pnpm-lock.yaml ./
RUN pnpm install --prod
COPY --from=development /usr/src/app/dist ./dist

CMD ["node", "dist/main"]
