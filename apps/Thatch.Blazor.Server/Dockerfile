#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["apps/Thatch.Blazor.Server/Thatch.Blazor.Server.csproj", "apps/Thatch.Blazor.Server/"]
RUN dotnet restore "apps/Thatch.Blazor.Server/Thatch.Blazor.Server.csproj"
COPY . .
WORKDIR "/src/apps/Thatch.Blazor.Server"
RUN dotnet build "Thatch.Blazor.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Thatch.Blazor.Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Thatch.Blazor.Server.dll"]