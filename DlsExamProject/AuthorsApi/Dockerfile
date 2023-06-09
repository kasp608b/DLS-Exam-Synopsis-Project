#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["AuthorsApi/AuthorsApi.csproj", "AuthorsApi/"]
COPY ["Common/Common.csproj", "Common/"]
RUN dotnet restore "AuthorsApi/AuthorsApi.csproj"
COPY . .
WORKDIR "/src/AuthorsApi"
RUN dotnet build "AuthorsApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AuthorsApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AuthorsApi.dll"]