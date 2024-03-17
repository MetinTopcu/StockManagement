#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Services/Basket/src/application/StockManagement.Basket.API/StockManagement.Basket.API.csproj", "Services/Basket/src/application/StockManagement.Basket.API/"]
RUN dotnet restore "Services/Basket/src/application/StockManagement.Basket.API/StockManagement.Basket.API.csproj"
COPY . .
WORKDIR "/src/Services/Basket/src/application/StockManagement.Basket.API"
RUN dotnet build "StockManagement.Basket.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StockManagement.Basket.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StockManagement.Basket.API.dll"]