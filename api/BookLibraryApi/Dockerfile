FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
ENV DOTNET_RUNNING_IN_CONTAINER=true

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copia apenas os arquivos de projeto e restaura dependências
COPY ["BookLibraryApi.csproj", "./"]
RUN dotnet restore "./BookLibraryApi.csproj"

# Copia o restante dos arquivos e publica
COPY . .
RUN dotnet publish "BookLibraryApi.csproj" -c Release -o /app/publish --no-restore

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "BookLibraryApi.dll"]