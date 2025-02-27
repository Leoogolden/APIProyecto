# For more info see: http://aka.ms/VSContainerToolingDockerfiles
FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS builder
WORKDIR /src
COPY *.sln ./
COPY ApiEjemplo/ApiEjemplo.csproj ApiEjemplo/
RUN dotnet restore
COPY . .
WORKDIR /src/ApiEjemplo
RUN dotnet build -c Release -o /app

FROM builder AS publish
RUN dotnet publish -c Release -o /app

FROM base AS production
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ApiEjemplo.dll"]
