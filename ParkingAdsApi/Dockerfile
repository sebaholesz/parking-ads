FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ParkingAdsApi/ParkingAdsApi.csproj", "ParkingAdsApi/"]
RUN dotnet restore "ParkingAdsApi/ParkingAdsApi.csproj"
COPY . .
WORKDIR "/src/ParkingAdsApi"
RUN dotnet build "ParkingAdsApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ParkingAdsApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ParkingAdsApi.dll"]
