sleep 90s
 
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P 123 -d master -i create-database.sql