FROM microsoft/dotnet:2.2-sdk AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY project-api/project-api.csproj project-api/
RUN dotnet restore project-api -nowarn:msb3202,nu1503
COPY . .
WORKDIR /src/project-api
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "project-api.dll"]
