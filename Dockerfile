# Stage 1: Build the project
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copy and restore the project files
COPY ARAppBackend/ARAppBackend.csproj ARAppBackend/
COPY Domain/Domain.csproj Domain/
COPY Infrastructure/Infrastructure.csproj Infrastructure/

RUN dotnet restore ARAppBackend/ARAppBackend.csproj

# Copy the entire project and publish
COPY . .
WORKDIR /app/ARAppBackend
RUN dotnet publish -c Release -o out

# Stage 2: Create the final runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app/ARAppBackend/out .


# Copy the published output and appsettings.json file
COPY --from=build /app/ARAppBackend/out .
COPY ARAppBackend/appsettings.json .

# Set environment variables for configurations
ENV Logging__LogLevel__Default=Information
ENV Logging__LogLevel__Microsoft.AspNetCore=Warning
ENV AllowedHosts=*
ENV AppSettings__Token=TestKeyToken1231231231231239879879876666asdbxcbassssssssss
ENV ConnectionStrings__ArAppConnection="workstation id=ArAppBackend.mssql.somee.com;packet size=4096;user id=MADMVX_SQLLogin_1;pwd=no145yiwh5;data source=ArAppBackend.mssql.somee.com;persist security info=False;initial catalog=ArAppBackend"
# Uncomment the line below and replace with the correct value if using Azure SQL Database
# ENV ConnectionStrings__ArAppConnection="server=arappbackenddbserver.database.windows.net; database=ARAppBackend_db;  user id=MADMVX; password=Coldfear1*"
ENV ConnectionStrings__CommunicationConnection=endpoint=https://arappcommunicationservice.communication.azure.com/;accesskey=LKSG1Etj6FBooPkCyou83BIL5TCpipMbJves1AoHndXr464GjXHSpKHhacBGXo/UBAz2kTsGCEk6AUNf9pMmww==


EXPOSE 80
EXPOSE 443

ENTRYPOINT ["dotnet", "ARAppBackend.dll"]
