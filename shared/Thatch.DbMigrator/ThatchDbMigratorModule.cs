using Thatch.Administration;
using Thatch.Administration.EntityFrameworkCore;
using Thatch.IdentityService;
using Thatch.IdentityService.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Thatch.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AdministrationEntityFrameworkCoreModule),
    typeof(AdministrationApplicationContractsModule),
    typeof(IdentityServiceEntityFrameworkCoreModule),
    typeof(IdentityServiceApplicationContractsModule)
)]
public class ThatchDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        //Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}