# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:9.0-alpine AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .

# copy everything else and build app
COPY src/. ./src/
RUN dotnet restore --runtime linux-musl-x64
WORKDIR /source/src
RUN dotnet publish ./BunIp.Web/BunIp.Web.csproj -c release -o /app --no-restore --runtime linux-musl-x64

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:9.0-alpine AS final
RUN apk add --upgrade --no-cache ca-certificates-bundle libgcc libssl3 libstdc++ zlib
ENV ASPNETCORE_HTTP_PORTS=8080
WORKDIR /app
COPY --from=build /app ./

ENTRYPOINT ["dotnet", "BunIp.Web.dll"]