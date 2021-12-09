FROM mysql

WORKDIR /var/lib/mysql
# copy over the SQL file to the container for automatic seeding of the MySQL DB
COPY *.sql /docker-entrypoint-initdb.d