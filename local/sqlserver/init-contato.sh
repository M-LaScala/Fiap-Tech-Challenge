sleep 40s

/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P techchanllenge@123  -d master -i /tmp/createdatabase.sql
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P techchanllenge@123  -d master -i /tmp/criandotabelas.sql