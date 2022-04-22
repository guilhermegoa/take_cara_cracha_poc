FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CaraCrachaPocket/CaraCrachaPocket.csproj", "CaraCrachaPocket/"]
RUN dotnet restore "CaraCrachaPocket/CaraCrachaPocket.csproj"
COPY . .
WORKDIR "/src/CaraCrachaPocket"
RUN dotnet build "CaraCrachaPocket.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CaraCrachaPocket.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CaraCrachaPocket.dll"]
