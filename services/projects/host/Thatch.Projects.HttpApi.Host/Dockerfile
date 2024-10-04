#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["services/projects/NuGet.Config", "services/projects/"]
COPY ["services/projects/host/Thatch.Projects.HttpApi.Host/Thatch.Projects.HttpApi.Host.csproj", "services/projects/host/Thatch.Projects.HttpApi.Host/"]
COPY ["services/projects/src/Thatch.Projects.HttpApi/Thatch.Projects.HttpApi.csproj", "services/projects/src/Thatch.Projects.HttpApi/"]
COPY ["services/projects/src/Thatch.Projects.Application.Contracts/Thatch.Projects.Application.Contracts.csproj", "services/projects/src/Thatch.Projects.Application.Contracts/"]
COPY ["services/projects/src/Thatch.Projects.Domain.Shared/Thatch.Projects.Domain.Shared.csproj", "services/projects/src/Thatch.Projects.Domain.Shared/"]
COPY ["services/projects/src/Thatch.Projects.Application/Thatch.Projects.Application.csproj", "services/projects/src/Thatch.Projects.Application/"]
COPY ["services/projects/src/Thatch.Projects.Domain/Thatch.Projects.Domain.csproj", "services/projects/src/Thatch.Projects.Domain/"]
COPY ["services/projects/src/Thatch.Projects.EntityFrameworkCore/Thatch.Projects.EntityFrameworkCore.csproj", "services/projects/src/Thatch.Projects.EntityFrameworkCore/"]
RUN dotnet restore "services/projects/host/Thatch.Projects.HttpApi.Host/Thatch.Projects.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/services/projects/host/Thatch.Projects.HttpApi.Host"
RUN dotnet build "Thatch.Projects.HttpApi.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Thatch.Projects.HttpApi.Host.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Thatch.Projects.HttpApi.Host.dll"]