#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster AS build
WORKDIR /src
COPY ["src/BunIp.Web/BunIp.Web.csproj", "src/BunIp.Web/"]
RUN dotnet restore "src/BunIp.Web/BunIp.Web.csproj"
COPY . .
WORKDIR "/src/src/BunIp.Web"
RUN dotnet build "BunIp.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BunIp.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BunIp.Web.dll"]