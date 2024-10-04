using Thatch.SaaS.Localization;
using Volo.Abp.Application.Services;

namespace Thatch.SaaS;

public abstract class SaaSAppService : ApplicationService
{
    protected SaaSAppService()
    {
        LocalizationResource = typeof(SaaSResource);
        ObjectMapperContext = typeof(SaaSApplicationModule);
    }
}