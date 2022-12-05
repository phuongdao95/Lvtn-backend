#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
EXPOSE 80
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["lvtn-backend/lvtn-backend.csproj", "lvtn-backend/"]
COPY ["Models/Models.csproj", "Models/"]
COPY ["Services/Services.csproj", "Services/"]
COPY ["Repositories/Repositories.csproj", "Repositories/"]
RUN dotnet restore "lvtn-backend/lvtn-backend.csproj"
COPY . .
WORKDIR "/src/lvtn-backend"
RUN dotnet build "lvtn-backend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "lvtn-backend.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "lvtn-backend.dll"]