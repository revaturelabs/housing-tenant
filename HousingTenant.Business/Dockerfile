FROM microsoft/dotnet:latest

WORKDIR /app
COPY ./HousingTenant.Business.Library /app/HousingTenant.Business.Library
COPY ./HousingTenant.Business.Service /app/HousingTenant.Business.Service

WORKDIR /app/HousingTenant.Business.Library
RUN dotnet restore
RUN dotnet build

WORKDIR /app/HousingTenant.Business.Service
RUN dotnet restore
RUN dotnet build

ENV ASPNETCORE_URLS="http://+:80"

CMD ["dotnet", "run"]
