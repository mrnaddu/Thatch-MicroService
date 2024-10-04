using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Thatch.Administration.EntityFrameworkCore;
using Thatch.IdentityService.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Uow;

namespace Thatch.DbMigrator;

public class ThatchDbMigrationService : ITransientDependency
{
    private readonly ICurrentTenant _currentTenant;
    private readonly IDataSeeder _dataSeeder;
    private readonly ILogger<ThatchDbMigrationService> _logger;
    private readonly IUnitOfWorkManager _unitOfWorkManager;

    public ThatchDbMigrationService(
        ILogger<ThatchDbMigrationService> logger,
        IDataSeeder dataSeeder,
        ICurrentTenant currentTenant,
        IUnitOfWorkManager unitOfWorkManager)
    {
        _logger = logger;
        _dataSeeder = dataSeeder;
        _currentTenant = currentTenant;
        _unitOfWorkManager = unitOfWorkManager;
    }

    public async Task MigrateAsync(CancellationToken cancellationToken)
    {
        await MigrateHostAsync(cancellationToken);
        await MigrateTenantsAsync(cancellationToken);
        _logger.LogInformation("Migration completed!");
    }

    private async Task MigrateHostAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Migrating Host side...");
        await MigrateAllDatabasesAsync(cancellationToken);
        await SeedDataAsync();
    }

    private async Task MigrateTenantsAsync(CancellationToken cancellationToken)
    {
        // Database schema migration
        _logger.LogInformation($"Migrating database");
        await MigrateAllDatabasesAsync(cancellationToken);
        //Seed data
        _logger.LogInformation($"Seeding Admin credentials to  database");
        await SeedDataAsync();
    }

    private async Task MigrateAllDatabasesAsync(CancellationToken cancellationToken)
    {
        using (var uow = _unitOfWorkManager.Begin(true))
        {
            await MigrateDatabaseAsync<AdministrationDbContext>(cancellationToken);
            await MigrateDatabaseAsync<IdentityServiceDbContext>(cancellationToken);

            await uow.CompleteAsync(cancellationToken);
        }

        _logger.LogInformation(
            $"All databases have been successfully migrated");
    }

    private async Task MigrateDatabaseAsync<TDbContext>(
        CancellationToken cancellationToken)
        where TDbContext : DbContext, IEfCoreDbContext
    {
        _logger.LogInformation($"Migrating {typeof(TDbContext).Name.RemovePostFix("DbContext")} database...");

        var dbContext = await _unitOfWorkManager.Current.ServiceProvider
            .GetRequiredService<IDbContextProvider<TDbContext>>()
            .GetDbContextAsync();

        await dbContext
            .Database
            .MigrateAsync(cancellationToken);
    }

    private async Task SeedDataAsync()
    {
        await _dataSeeder.SeedAsync(
            new DataSeedContext(_currentTenant.Id)
                .WithProperty(IdentityDataSeedContributor.AdminEmailPropertyName, "admin@abp.io")
                .WithProperty(IdentityDataSeedContributor.AdminPasswordPropertyName, "1q2w3E*")
        );
    }
}