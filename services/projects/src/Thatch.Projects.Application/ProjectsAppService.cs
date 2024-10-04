using Thatch.Projects.Localization;
using Volo.Abp.Application.Services;

namespace Thatch.Projects;

public abstract class ProjectsAppService : ApplicationService
{
    protected ProjectsAppService()
    {
        LocalizationResource = typeof(ProjectsResource);
        ObjectMapperContext = typeof(ProjectsApplicationModule);
    }
}