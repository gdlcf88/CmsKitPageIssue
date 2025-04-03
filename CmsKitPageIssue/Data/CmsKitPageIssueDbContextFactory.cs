using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CmsKitPageIssue.Data;

public class CmsKitPageIssueDbContextFactory : IDesignTimeDbContextFactory<CmsKitPageIssueDbContext>
{
    public CmsKitPageIssueDbContext CreateDbContext(string[] args)
    {
        CmsKitPageIssueEfCoreEntityExtensionMappings.Configure();
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<CmsKitPageIssueDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new CmsKitPageIssueDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}