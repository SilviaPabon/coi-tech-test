# Credits to https://blog.genezini.com/p/how-to-run-scripts-on-sql-server-container-startup/
FROM mcr.microsoft.com/mssql/server:2022-latest

# Create a config directory
RUN mkdir /tmp/initscripts

# Bundle config source
COPY . /tmp/initscripts

ENTRYPOINT ["/tmp/initscripts/entrypoint.sh"]