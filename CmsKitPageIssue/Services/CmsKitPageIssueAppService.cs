using Volo.Abp.Application.Services;
using CmsKitPageIssue.Localization;

namespace CmsKitPageIssue.Services;

/* Inherit your application services from this class. */
public abstract class CmsKitPageIssueAppService : ApplicationService
{
    protected CmsKitPageIssueAppService()
    {
        LocalizationResource = typeof(CmsKitPageIssueResource);
    }
}