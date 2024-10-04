using Volo.Abp.Modularity;

namespace Thatch.Administration;

[DependsOn(
    typeof(AdministrationApplicationModule),
    typeof(AdministrationDomainTestModule)
    )]
public class AdministrationApplicationTestModule : AbpModule
{

}
