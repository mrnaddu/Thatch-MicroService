using Thatch.Administration.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Thatch.Administration;

public abstract class AdministrationController : AbpControllerBase
{
    protected AdministrationController()
    {
        LocalizationResource = typeof(AdministrationResource);
    }
}