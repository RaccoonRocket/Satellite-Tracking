FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY SatelliteTracking.Core/SatelliteTracking.Core.csproj SatelliteTracking.Core/
COPY SatelliteTracking.Web/SatelliteTracking.Web.csproj SatelliteTracking.Web/
RUN dotnet restore SatelliteTracking.Web/SatelliteTracking.Web.csproj

COPY . .
RUN dotnet publish SatelliteTracking.Web/SatelliteTracking.Web.csproj \
    --configuration Release \
    --output /app/publish \
    /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "SatelliteTracking.Web.dll"]
