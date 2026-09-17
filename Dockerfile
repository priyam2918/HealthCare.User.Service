FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/Services/UserService/UserService.API/UserService.API.csproj", "src/Services/UserService/UserService.API/"]
COPY ["src/Services/UserService/UserService.Application/UserService.Application.csproj", "src/Services/UserService/UserService.Application/"]
COPY ["src/Services/UserService/UserService.Infrastructure/UserService.Infrastructure.csproj", "src/Services/UserService/UserService.Infrastructure/"]
COPY ["src/Services/UserService/UserService.Domain/UserService.Domain.csproj", "src/Services/UserService/UserService.Domain/"]
COPY ["src/BuildingBlocks/Common/Common.csproj", "src/BuildingBlocks/Common/"]
RUN dotnet restore "src/Services/UserService/UserService.API/UserService.API.csproj"
COPY . .
WORKDIR "/src/src/Services/UserService/UserService.API"
RUN dotnet build "UserService.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UserService.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UserService.API.dll"]
