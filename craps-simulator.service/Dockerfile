#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["craps-simulator.service/craps-simulator.service.csproj", "craps-simulator.service/"]
COPY ["craps-simulator.lib/craps-simulator.lib.csproj", "craps-simulator.lib/"]
RUN dotnet restore "craps-simulator.service/craps-simulator.service.csproj"
COPY . .
WORKDIR "/src/craps-simulator.service"
RUN dotnet build "craps-simulator.service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "craps-simulator.service.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "craps-simulator.service.dll"]