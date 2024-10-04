using Thatch.SaaS.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Thatch.SaaS;

public abstract class SaaSController : AbpControllerBase
{
    protected SaaSController()
    {
        LocalizationResource = typeof(SaaSResource);
    }
}