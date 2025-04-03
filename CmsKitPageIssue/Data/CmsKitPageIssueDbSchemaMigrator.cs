using Volo.Abp.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace CmsKitPageIssue.Data;

public class CmsKitPageIssueDbSchemaMigrator : ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public CmsKitPageIssueDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        
        /* We intentionally resolving the CmsKitPageIssueDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<CmsKitPageIssueDbContext>()
            .Database
            .MigrateAsync();

    }
}
