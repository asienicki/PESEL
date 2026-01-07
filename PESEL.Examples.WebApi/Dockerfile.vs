FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Debug
WORKDIR /src
COPY ["PESEL.Examples.WebApi/PESEL.Examples.WebApi.csproj", "PESEL.Examples.WebApi/"]
RUN dotnet restore "./PESEL.Examples.WebApi/PESEL.Examples.WebApi.csproj"
COPY . .
WORKDIR "/src/PESEL.Examples.WebApi"
RUN dotnet build "./PESEL.Examples.WebApi.csproj" -c "$BUILD_CONFIGURATION" -o /app/build

FROM build AS publish
RUN dotnet publish "./PESEL.Examples.WebApi.csproj" -c "$BUILD_CONFIGURATION" -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PESEL.Examples.WebApi.dll"]
