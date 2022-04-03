FROM mcr.microsoft.com/mssql/server:2017-CU24-ubuntu-16.04
COPY ./Blocks/Database/Scripts /
RUN chmod +x ./SqlCmdStartup.sh
CMD /bin/bash ./entrypoint.sh

#FROM mcr.microsoft.com/mssql/server:2019-latest 
## Create work directory
#RUN mkdir -p /usr/work
#WORKDIR /usr/work
## Copy all scripts into working directory
#COPY . /usr/work/
## Grant permissions for the SqlCmdStartup script to be executable
#RUN chmod +x /usr/work/SqlCmdStartup.sh
#EXPOSE 1433
#CMD /bin/bash ./entrypoint.sh