using CmsKitPageIssue.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace CmsKitPageIssue.Permissions;

public class CmsKitPageIssuePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(CmsKitPageIssuePermissions.GroupName);

        
        //Define your own permissions here. Example:
        //myGroup.AddPermission(CmsKitPageIssuePermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<CmsKitPageIssueResource>(name);
    }
}
