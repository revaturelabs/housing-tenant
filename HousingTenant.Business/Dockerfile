FROM microsoft/dotnet:latest
WORKDIR /app
COPY . /app
RUN dotnet restore
CMD ["dotnet", "run", "--project" , "./HousingTenant.Business.Service/HousingTenant.Business.Service.csproj"]
