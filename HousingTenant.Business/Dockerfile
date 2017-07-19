FROM microsoft/dotnet:latest
WORKDIR /app
COPY . /app
RUN dotnet restore
RUN dotnet build
WORKDIR HousingTenant.Business.Service
CMD ["ASPNETCORE_URLS=\"http://*:80\"", "dotnet", "run"]
