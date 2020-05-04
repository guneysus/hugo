FROM microsoft/dotnet:2.2-sdk AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY user-api/user-api.csproj user-api/
RUN dotnet restore user-api -nowarn:msb3202,nu1503
COPY . .
WORKDIR /src/user-api
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "user-api.dll"]
