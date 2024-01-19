FROM postgres

ENV POSTGRES_PASSWORD test
ENV POSTGRES_DB TestDB
ENV POSTGRES_USER test
ENV POSTGRES_HOST_AUTH_METHOD trust

## todos los scripts en  docker-entrypoint-initdb.d/ se ejecutan automaticamente
COPY ./Database/ ./docker-entrypoint-initdb.d/