#!/bin/bash

# Calls SQLCMD to verify that system and user databases are in an "online" state,
# then run the configuration script (setup.sql)

TRIES=60
DBSTATUS=1
i=0

while [[ $DBSTATUS -ne 0 ]] && [[ $i -lt $TRIES ]]; do
    i=$((i+1))
    
    # Añadimos -C para confiar en el certificado del servidor
    DBSTATUS=$(/opt/mssql-tools18/bin/sqlcmd -h -1 -t 1 -U sa -P $MSSQL_SA_PASSWORD -C -q "SET NOCOUNT ON; SELECT COALESCE(SUM(state), 0) FROM sys.databases") || DBSTATUS=1
    
    echo "Attempt $i of $TRIES. DB Status: $DBSTATUS"
    sleep 1s
done

if [ $DBSTATUS -ne 0 ]; then 
    echo "SQL Server took more than $TRIES seconds to start up or one or more databases are not in an ONLINE state"
    exit 1
fi

# Run the setup script to create the DB and the schema in the DB
echo "Running configuration script..."

# También añadimos -C aquí
/opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P $MSSQL_SA_PASSWORD -C -d master -i /tmp/initscripts/setup.sql

echo "Configuration completed."