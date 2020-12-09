#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["RetoWallmart.API/RetoWallmart.API.csproj", "RetoWallmart.API/"]
RUN dotnet restore "RetoWallmart.API/RetoWallmart.API.csproj"
COPY . .
WORKDIR "/src/RetoWallmart.API"
RUN dotnet build "RetoWallmart.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RetoWallmart.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RetoWallmart.API.dll"]