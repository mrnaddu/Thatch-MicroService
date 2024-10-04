using Thatch.Administration.EntityFrameworkCore;
using Thatch.Hosting.Shared;
using Volo.Abp.Modularity;

namespace Thatch.Microservice.Shared;

[DependsOn(
    typeof(ThatchHostingModule),
    typeof(AdministrationEntityFrameworkCoreModule)
)]
public class ThatchMicroserviceModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
    }
}