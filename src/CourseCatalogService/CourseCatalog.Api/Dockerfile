# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/CourseCatalogService/CourseCatalog.Api/CourseCatalog.Api.csproj", "src/CourseCatalogService/CourseCatalog.Api/"]
COPY ["src/CourseCatalogService/CourseCatalog.Application/CourseCatalog.Application.csproj", "src/CourseCatalogService/CourseCatalog.Application/"]
COPY ["src/CourseCatalogService/CourseCatalog.Contracts/CourseCatalog.Contracts.csproj", "src/CourseCatalogService/CourseCatalog.Contracts/"]
COPY ["src/CourseCatalogService/CourseCatalog.Domain/CourseCatalog.Domain.csproj", "src/CourseCatalogService/CourseCatalog.Domain/"]
COPY ["src/CourseCatalogService/CourseCatalog.Infrastructure/CourseCatalog.Infrastructure.csproj", "src/CourseCatalogService/CourseCatalog.Infrastructure/"]
RUN dotnet restore "./src/CourseCatalogService/CourseCatalog.Api/CourseCatalog.Api.csproj"
COPY . .
WORKDIR "/src/src/CourseCatalogService/CourseCatalog.Api"
RUN dotnet build "./CourseCatalog.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CourseCatalog.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CourseCatalog.Api.dll"]