#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["services/administration/NuGet.Config", "services/administration/"]
COPY ["services/identity/NuGet.Config", "services/identity/"]
COPY ["services/saas/NuGet.Config", "services/saas/"]
COPY ["shared/Thatch.DbMigrator/Thatch.DbMigrator.csproj", "shared/Thatch.DbMigrator/"]
COPY ["services/administration/src/Thatch.Administration.Application.Contracts/Thatch.Administration.Application.Contracts.csproj", "services/administration/src/Thatch.Administration.Application.Contracts/"]
COPY ["services/administration/src/Thatch.Administration.Domain.Shared/Thatch.Administration.Domain.Shared.csproj", "services/administration/src/Thatch.Administration.Domain.Shared/"]
COPY ["services/administration/src/Thatch.Administration.EntityFrameworkCore/Thatch.Administration.EntityFrameworkCore.csproj", "services/administration/src/Thatch.Administration.EntityFrameworkCore/"]
COPY ["services/administration/src/Thatch.Administration.Domain/Thatch.Administration.Domain.csproj", "services/administration/src/Thatch.Administration.Domain/"]
COPY ["services/identity/src/Thatch.IdentityService.Application.Contracts/Thatch.IdentityService.Application.Contracts.csproj", "services/identity/src/Thatch.IdentityService.Application.Contracts/"]
COPY ["services/identity/src/Thatch.IdentityService.Domain.Shared/Thatch.IdentityService.Domain.Shared.csproj", "services/identity/src/Thatch.IdentityService.Domain.Shared/"]
COPY ["services/identity/src/Thatch.IdentityService.EntityFrameworkCore/Thatch.IdentityService.EntityFrameworkCore.csproj", "services/identity/src/Thatch.IdentityService.EntityFrameworkCore/"]
COPY ["services/identity/src/Thatch.IdentityService.Domain/Thatch.IdentityService.Domain.csproj", "services/identity/src/Thatch.IdentityService.Domain/"]
COPY ["services/saas/src/Thatch.SaaS.Application.Contracts/Thatch.SaaS.Application.Contracts.csproj", "services/saas/src/Thatch.SaaS.Application.Contracts/"]
COPY ["services/saas/src/Thatch.SaaS.Domain.Shared/Thatch.SaaS.Domain.Shared.csproj", "services/saas/src/Thatch.SaaS.Domain.Shared/"]
COPY ["services/saas/src/Thatch.SaaS.EntityFrameworkCore/Thatch.SaaS.EntityFrameworkCore.csproj", "services/saas/src/Thatch.SaaS.EntityFrameworkCore/"]
COPY ["services/saas/src/Thatch.SaaS.Domain/Thatch.SaaS.Domain.csproj", "services/saas/src/Thatch.SaaS.Domain/"]
COPY ["shared/Thatch.Microservice.Shared/Thatch.Microservice.Shared.csproj", "shared/Thatch.Microservice.Shared/"]
COPY ["shared/Thatch.Hosting.Shared/Thatch.Hosting.Shared.csproj", "shared/Thatch.Hosting.Shared/"]
RUN dotnet restore "shared/Thatch.DbMigrator/Thatch.DbMigrator.csproj"
COPY . .
WORKDIR "/src/shared/Thatch.DbMigrator"
RUN dotnet build "Thatch.DbMigrator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Thatch.DbMigrator.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Thatch.DbMigrator.dll"]