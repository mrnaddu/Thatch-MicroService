using Volo.Abp.Modularity;

namespace Thatch.SaaS;

[DependsOn(
    typeof(SaaSApplicationModule),
    typeof(SaaSDomainTestModule)
    )]
public class SaaSApplicationTestModule : AbpModule
{

}
