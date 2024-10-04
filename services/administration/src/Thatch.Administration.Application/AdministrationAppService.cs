using Thatch.Administration.Localization;
using Volo.Abp.Application.Services;

namespace Thatch.Administration;

public abstract class AdministrationAppService : ApplicationService
{
    protected AdministrationAppService()
    {
        LocalizationResource = typeof(AdministrationResource);
        ObjectMapperContext = typeof(AdministrationApplicationModule);
    }
}