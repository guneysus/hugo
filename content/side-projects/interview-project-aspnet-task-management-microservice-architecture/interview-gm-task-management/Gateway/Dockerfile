FROM microsoft/dotnet:2.2-sdk AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY Gateway/Gateway.csproj Gateway/
RUN dotnet restore Gateway -nowarn:msb3202,nu1503
COPY . .
WORKDIR /src/Gateway
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Gateway.dll"]
