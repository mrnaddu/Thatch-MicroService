#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["services/saas/NuGet.Config", "services/saas/"]
COPY ["services/administration/NuGet.Config", "services/administration/"]
COPY ["services/saas/host/Thatch.SaaS.HttpApi.Host/Thatch.SaaS.HttpApi.Host.csproj", "services/saas/host/Thatch.SaaS.HttpApi.Host/"]
COPY ["shared/Thatch.Hosting.Shared/Thatch.Hosting.Shared.csproj", "shared/Thatch.Hosting.Shared/"]
COPY ["services/administration/src/Thatch.Administration.EntityFrameworkCore/Thatch.Administration.EntityFrameworkCore.csproj", "services/administration/src/Thatch.Administration.EntityFrameworkCore/"]
COPY ["services/administration/src/Thatch.Administration.Domain/Thatch.Administration.Domain.csproj", "services/administration/src/Thatch.Administration.Domain/"]
COPY ["services/administration/src/Thatch.Administration.Domain.Shared/Thatch.Administration.Domain.Shared.csproj", "services/administration/src/Thatch.Administration.Domain.Shared/"]
COPY ["services/saas/src/Thatch.SaaS.HttpApi/Thatch.SaaS.HttpApi.csproj", "services/saas/src/Thatch.SaaS.HttpApi/"]
COPY ["services/saas/src/Thatch.SaaS.Application.Contracts/Thatch.SaaS.Application.Contracts.csproj", "services/saas/src/Thatch.SaaS.Application.Contracts/"]
COPY ["services/saas/src/Thatch.SaaS.Domain.Shared/Thatch.SaaS.Domain.Shared.csproj", "services/saas/src/Thatch.SaaS.Domain.Shared/"]
COPY ["services/saas/src/Thatch.SaaS.Application/Thatch.SaaS.Application.csproj", "services/saas/src/Thatch.SaaS.Application/"]
COPY ["services/saas/src/Thatch.SaaS.Domain/Thatch.SaaS.Domain.csproj", "services/saas/src/Thatch.SaaS.Domain/"]
COPY ["services/saas/src/Thatch.SaaS.EntityFrameworkCore/Thatch.SaaS.EntityFrameworkCore.csproj", "services/saas/src/Thatch.SaaS.EntityFrameworkCore/"]
RUN dotnet restore "services/saas/host/Thatch.SaaS.HttpApi.Host/Thatch.SaaS.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/services/saas/host/Thatch.SaaS.HttpApi.Host"
RUN dotnet build "Thatch.SaaS.HttpApi.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Thatch.SaaS.HttpApi.Host.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Thatch.SaaS.HttpApi.Host.dll"]