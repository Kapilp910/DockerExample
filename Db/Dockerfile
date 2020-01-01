FROM mysql:5.7.13
COPY Db/*.sql /docker-entrypoint-initdb.d
ENV MYSQL_ROOT_PASSWORD mypass
EXPOSE 3306