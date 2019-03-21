FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY CustomersApi/CustomersApi.csproj CustomersApi/
COPY SharedModels/SharedModels.csproj SharedModels/
RUN dotnet restore CustomersApi/CustomersApi.csproj
COPY . .
WORKDIR /src/CustomersApi
RUN dotnet build CustomersApi.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish CustomersApi.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CustomersApi.dll"]
