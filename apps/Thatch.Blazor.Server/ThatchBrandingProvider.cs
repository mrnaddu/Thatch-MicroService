using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Thatch.Blazor.Server;

[Dependency(ReplaceServices = true)]
public class ThatchBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Thatch";
}
