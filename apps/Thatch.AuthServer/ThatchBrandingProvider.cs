using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Thatch;

[Dependency(ReplaceServices = true)]
public class ThatchBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Thatch";
}
