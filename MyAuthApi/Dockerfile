# STAGE 1: Base Runtime Image (used in final stage)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# STAGE 2: Build Image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore early to leverage Docker layer caching
COPY ["MyAuthApi/MyAuthApi.csproj", "MyAuthApi/"]
RUN dotnet restore "MyAuthApi/MyAuthApi.csproj"

# Copy everything and build
COPY . .
WORKDIR "/src/MyAuthApi"
RUN dotnet build "MyAuthApi.csproj" -c Release -o /app/build

# STAGE 3: Publish Image
FROM build AS publish
RUN dotnet publish "MyAuthApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

# STAGE 4: Final Runtime Image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyAuthApi.dll"]
