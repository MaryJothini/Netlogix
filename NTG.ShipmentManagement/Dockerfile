#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["NTG.ShipmentManagement.Api/NTG.ShipmentManagement.Api.csproj", "NTG.ShipmentManagement.Api/"]
COPY ["NTG.ShipmentManagement.Infrastructure/NTG.ShipmentManagement.Infrastructure.csproj", "NTG.ShipmentManagement.Infrastructure/"]
COPY ["NTG.ShipmentManagement.Applicaiton/NTG.ShipmentManagement.Applicaiton.csproj", "NTG.ShipmentManagement.Applicaiton/"]
COPY ["NTG.ShipmentManagement.Domain/NTG.ShipmentManagement.Domain.csproj", "NTG.ShipmentManagement.Domain/"]
COPY ["NTG.ShipmentManagement.Persistence/NTG.ShipmentManagement.Persistence.csproj", "NTG.ShipmentManagement.Persistence/"]
COPY ["NTG.ShipmentManagement.Identity/NTG.ShipmentManagement.Identity.csproj", "NTG.ShipmentManagement.Identity/"]
RUN dotnet restore "NTG.ShipmentManagement.Api/NTG.ShipmentManagement.Api.csproj"
COPY . .
WORKDIR "/src/NTG.ShipmentManagement.Api"
RUN dotnet build "NTG.ShipmentManagement.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NTG.ShipmentManagement.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NTG.ShipmentManagement.Api.dll"]