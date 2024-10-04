#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["services/identity/NuGet.Config", "services/identity/"]
COPY ["services/administration/NuGet.Config", "services/administration/"]
COPY ["services/saas/NuGet.Config", "services/saas/"]
COPY ["services/identity/host/Thatch.IdentityService.HttpApi.Host/Thatch.IdentityService.HttpApi.Host.csproj", "services/identity/host/Thatch.IdentityService.HttpApi.Host/"]
COPY ["shared/Thatch.Hosting.Shared/Thatch.Hosting.Shared.csproj", "shared/Thatch.Hosting.Shared/"]
COPY ["services/administration/src/Thatch.Administration.EntityFrameworkCore/Thatch.Administration.EntityFrameworkCore.csproj", "services/administration/src/Thatch.Administration.EntityFrameworkCore/"]
COPY ["services/administration/src/Thatch.Administration.Domain/Thatch.Administration.Domain.csproj", "services/administration/src/Thatch.Administration.Domain/"]
COPY ["services/administration/src/Thatch.Administration.Domain.Shared/Thatch.Administration.Domain.Shared.csproj", "services/administration/src/Thatch.Administration.Domain.Shared/"]
COPY ["services/saas/src/Thatch.SaaS.EntityFrameworkCore/Thatch.SaaS.EntityFrameworkCore.csproj", "services/saas/src/Thatch.SaaS.EntityFrameworkCore/"]
COPY ["services/saas/src/Thatch.SaaS.Domain/Thatch.SaaS.Domain.csproj", "services/saas/src/Thatch.SaaS.Domain/"]
COPY ["services/saas/src/Thatch.SaaS.Domain.Shared/Thatch.SaaS.Domain.Shared.csproj", "services/saas/src/Thatch.SaaS.Domain.Shared/"]
COPY ["services/identity/src/Thatch.IdentityService.HttpApi/Thatch.IdentityService.HttpApi.csproj", "services/identity/src/Thatch.IdentityService.HttpApi/"]
COPY ["services/identity/src/Thatch.IdentityService.Application.Contracts/Thatch.IdentityService.Application.Contracts.csproj", "services/identity/src/Thatch.IdentityService.Application.Contracts/"]
COPY ["services/identity/src/Thatch.IdentityService.Domain.Shared/Thatch.IdentityService.Domain.Shared.csproj", "services/identity/src/Thatch.IdentityService.Domain.Shared/"]
COPY ["services/identity/src/Thatch.IdentityService.Application/Thatch.IdentityService.Application.csproj", "services/identity/src/Thatch.IdentityService.Application/"]
COPY ["services/identity/src/Thatch.IdentityService.Domain/Thatch.IdentityService.Domain.csproj", "services/identity/src/Thatch.IdentityService.Domain/"]
COPY ["services/identity/src/Thatch.IdentityService.EntityFrameworkCore/Thatch.IdentityService.EntityFrameworkCore.csproj", "services/identity/src/Thatch.IdentityService.EntityFrameworkCore/"]
RUN dotnet restore "services/identity/host/Thatch.IdentityService.HttpApi.Host/Thatch.IdentityService.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/services/identity/host/Thatch.IdentityService.HttpApi.Host"
RUN dotnet build "Thatch.IdentityService.HttpApi.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Thatch.IdentityService.HttpApi.Host.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Thatch.IdentityService.HttpApi.Host.dll"]