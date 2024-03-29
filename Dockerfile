# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .

# copy everything else and build app
COPY src/. ./src/
RUN dotnet restore
WORKDIR /source/src
RUN dotnet publish ./BunIp.Web/BunIp.Web.csproj -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app ./

ENTRYPOINT ["dotnet", "BunIp.Web.dll"]