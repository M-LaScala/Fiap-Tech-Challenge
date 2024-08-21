FROM mcr.microsoft.com/mssql/server:2022-latest

WORKDIR /usr/src/app

COPY . /usr/src/app

ENV MSSQL_SA_PASSWORD: techchanllenge@123
ENV ACCEPT_EULA: "Y"
VOLUME ./opt/mssql/bin/sqlserver
EXPOSE 1433

CMD /bin/bash ./entrypoint.sh