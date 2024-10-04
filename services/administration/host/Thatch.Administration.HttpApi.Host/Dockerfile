#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["services/administration/NuGet.Config", "services/administration/"]
COPY ["services/identity/NuGet.Config", "services/identity/"]
COPY ["services/saas/NuGet.Config", "services/saas/"]
COPY ["services/administration/host/Thatch.Administration.HttpApi.Host/Thatch.Administration.HttpApi.Host.csproj", "services/administration/host/Thatch.Administration.HttpApi.Host/"]
COPY ["shared/Thatch.Hosting.Shared/Thatch.Hosting.Shared.csproj", "shared/Thatch.Hosting.Shared/"]
COPY ["services/identity/src/Thatch.IdentityService.Application.Contracts/Thatch.IdentityService.Application.Contracts.csproj", "services/identity/src/Thatch.IdentityService.Application.Contracts/"]
COPY ["services/identity/src/Thatch.IdentityService.Domain.Shared/Thatch.IdentityService.Domain.Shared.csproj", "services/identity/src/Thatch.IdentityService.Domain.Shared/"]
COPY ["services/identity/src/Thatch.IdentityService.EntityFrameworkCore/Thatch.IdentityService.EntityFrameworkCore.csproj", "services/identity/src/Thatch.IdentityService.EntityFrameworkCore/"]
COPY ["services/identity/src/Thatch.IdentityService.Domain/Thatch.IdentityService.Domain.csproj", "services/identity/src/Thatch.IdentityService.Domain/"]
COPY ["services/saas/src/Thatch.SaaS.Application.Contracts/Thatch.SaaS.Application.Contracts.csproj", "services/saas/src/Thatch.SaaS.Application.Contracts/"]
COPY ["services/saas/src/Thatch.SaaS.Domain.Shared/Thatch.SaaS.Domain.Shared.csproj", "services/saas/src/Thatch.SaaS.Domain.Shared/"]
COPY ["services/administration/src/Thatch.Administration.HttpApi/Thatch.Administration.HttpApi.csproj", "services/administration/src/Thatch.Administration.HttpApi/"]
COPY ["services/administration/src/Thatch.Administration.Application.Contracts/Thatch.Administration.Application.Contracts.csproj", "services/administration/src/Thatch.Administration.Application.Contracts/"]
COPY ["services/administration/src/Thatch.Administration.Domain.Shared/Thatch.Administration.Domain.Shared.csproj", "services/administration/src/Thatch.Administration.Domain.Shared/"]
COPY ["services/administration/src/Thatch.Administration.Application/Thatch.Administration.Application.csproj", "services/administration/src/Thatch.Administration.Application/"]
COPY ["services/administration/src/Thatch.Administration.Domain/Thatch.Administration.Domain.csproj", "services/administration/src/Thatch.Administration.Domain/"]
COPY ["services/administration/src/Thatch.Administration.EntityFrameworkCore/Thatch.Administration.EntityFrameworkCore.csproj", "services/administration/src/Thatch.Administration.EntityFrameworkCore/"]
RUN dotnet restore "services/administration/host/Thatch.Administration.HttpApi.Host/Thatch.Administration.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/services/administration/host/Thatch.Administration.HttpApi.Host"
RUN dotnet build "Thatch.Administration.HttpApi.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Thatch.Administration.HttpApi.Host.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Thatch.Administration.HttpApi.Host.dll"]