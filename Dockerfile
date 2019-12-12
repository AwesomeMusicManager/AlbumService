FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["AwesomeMusicManager.AlbumService/AwesomeMusicManager.AlbumService.WebApi/AwesomeMusicManager.AlbumService.WebApi.csproj", "AwesomeMusicManager.AlbumService/AwesomeMusicManager.AlbumService.WebApi/"]
RUN dotnet restore "AwesomeMusicManager.AlbumService/AwesomeMusicManager.AlbumService.WebApi/AwesomeMusicManager.AlbumService.WebApi.csproj"
COPY . .
WORKDIR "/src/AwesomeMusicManager.AlbumService/AwesomeMusicManager.AlbumService.WebApi"
RUN dotnet build "AwesomeMusicManager.AlbumService.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AwesomeMusicManager.AlbumService.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AwesomeMusicManager.AlbumService.WebApi.dll"]
