# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS with-node
RUN apt-get update
RUN apt-get install curl
RUN curl -sL https://deb.nodesource.com/setup_20.x | bash
RUN apt-get -y install nodejs

RUN apt update && apt install -y wget curl gnupg \
  libnss3 libatk-bridge2.0-0 libgtk-3-0 libxss1 libasound2 libxshmfence1 libgbm1 libdrm2

FROM with-node AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Infotech-RegistrySearch-MatthewBrady.Server/Infotech-RegistrySearch-MatthewBrady.Server.csproj", "Infotech-RegistrySearch-MatthewBrady.Server/"]
COPY ["infotech-registrysearch-matthewbrady.client/infotech-registrysearch-matthewbrady.client.esproj", "infotech-registrysearch-matthewbrady.client/"]
RUN dotnet restore "./Infotech-RegistrySearch-MatthewBrady.Server/Infotech-RegistrySearch-MatthewBrady.Server.csproj"
COPY . .
WORKDIR "/src/Infotech-RegistrySearch-MatthewBrady.Server"
RUN dotnet build "./Infotech-RegistrySearch-MatthewBrady.Server.csproj" -c $BUILD_CONFIGURATION -o /app/build

RUN playwright install

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Infotech-RegistrySearch-MatthewBrady.Server.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Infotech-RegistrySearch-MatthewBrady.Server.dll"]
