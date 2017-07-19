FROM microsoft/dotnet:latest

WORKDIR /app
COPY ./HousingTenant.Data.Library /app/HousingTenant.Data.Library
COPY ./HousingTenant.Data.Service /app/HousingTenant.Data.Service

WORKDIR /app/HousingTenant.Data.Library
RUN dotnet restore
RUN dotnet build

WORKDIR /app/HousingTenant.Data.Service
RUN dotnet restore
RUN dotnet build

ENV ASPNETCORE_URLS="http://+:80"

CMD ["dotnet", "run"]
