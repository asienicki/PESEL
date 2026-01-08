FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_HTTP_PORTS=8080
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS publish
WORKDIR /src

COPY ["PESEL.Examples.WebApi.csproj", "./"]
RUN dotnet restore "PESEL.Examples.WebApi.csproj"

COPY . .
RUN dotnet publish "PESEL.Examples.WebApi.csproj" \
    -c Release \
    -o /app/publish \
    /p:UseAppHost=false

FROM base AS final
WORKDIR /app
LABEL org.opencontainers.image.source="https://github.com/asienicki/pesel"
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PESEL.Examples.WebApi.dll"]
