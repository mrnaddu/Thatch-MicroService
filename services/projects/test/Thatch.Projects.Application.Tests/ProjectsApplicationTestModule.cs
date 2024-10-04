using Volo.Abp.Modularity;

namespace Thatch.Projects;

[DependsOn(
    typeof(ProjectsApplicationModule),
    typeof(ProjectsDomainTestModule)
    )]
public class ProjectsApplicationTestModule : AbpModule
{

}
