using Thatch.Projects.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Thatch.Projects;

public abstract class ProjectsController : AbpControllerBase
{
    protected ProjectsController()
    {
        LocalizationResource = typeof(ProjectsResource);
    }
}