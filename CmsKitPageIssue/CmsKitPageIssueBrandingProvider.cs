using Microsoft.Extensions.Localization;
using CmsKitPageIssue.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace CmsKitPageIssue;

[Dependency(ReplaceServices = true)]
public class CmsKitPageIssueBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<CmsKitPageIssueResource> _localizer;

    public CmsKitPageIssueBrandingProvider(IStringLocalizer<CmsKitPageIssueResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}