#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["BakeryShop.WebApp/BakeryShop.WebApp.csproj", "BakeryShop.WebApp/"]
COPY ["BakeryShop.Domain/BakeryShop.Domain.csproj", "BakeryShop.Domain/"]
COPY ["BakeryShop.DataAccess/BakeryShop.DataAccess.csproj", "BakeryShop.DataAccess/"]
RUN dotnet restore "BakeryShop.WebApp/BakeryShop.WebApp.csproj"
COPY . .
WORKDIR "/src/BakeryShop.WebApp"
RUN dotnet build "BakeryShop.WebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BakeryShop.WebApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BakeryShop.WebApp.dll"]