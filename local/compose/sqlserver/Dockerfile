FROM mcr.microsoft.com/mssql/server:2022-latest

WORKDIR /usr/src/app

COPY . /usr/src/app

ENV SA_PASSWORD @d5^5kUPjhFd-74
ENV ACCEPT_EULA Y

EXPOSE 1433

CMD /bin/bash ./entrypoint.sh