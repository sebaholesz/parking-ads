FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AdService/AdService.csproj", "AdService/"]
RUN dotnet restore "AdService/AdService.csproj"
COPY . .
WORKDIR "/src/AdService"
RUN dotnet build "AdService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AdService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AdService.dll"]
