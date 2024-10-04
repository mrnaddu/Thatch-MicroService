using Thatch.IdentityService.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Thatch.IdentityService;

public abstract class IdentityServiceController : AbpControllerBase
{
    protected IdentityServiceController()
    {
        LocalizationResource = typeof(IdentityServiceResource);
    }
}