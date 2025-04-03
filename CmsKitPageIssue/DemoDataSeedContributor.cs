using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.MultiTenancy;
using Volo.Abp.TenantManagement;
using Volo.Abp.Uow;
using Volo.CmsKit.Pages;

namespace CmsKitPageIssue;

public class DemoDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly ICurrentTenant _currentTenant;
    private readonly ITenantManager _tenantManager;
    private readonly ITenantRepository _tenantRepository;
    private readonly PageManager _pageManager;
    private readonly IPageRepository _pageRepository;

    public DemoDataSeedContributor(
        ICurrentTenant currentTenant,
        ITenantManager tenantManager,
        ITenantRepository tenantRepository,
        PageManager pageManager,
        IPageRepository pageRepository)
    {
        _currentTenant = currentTenant;
        _tenantManager = tenantManager;
        _tenantRepository = tenantRepository;
        _pageManager = pageManager;
        _pageRepository = pageRepository;
    }

    public virtual async Task SeedAsync(DataSeedContext context)
    {
        // await TryCreateHomePageAsync(null, "Host home page"); // todo: You enable this line, the problem is gone.

        var tenant = await GetOrCreateDemoTenantAsync();

        await TryCreateHomePageAsync(tenant, "Tenant home page");
    }

    [UnitOfWork]
    protected virtual async Task TryCreateHomePageAsync(Tenant? tenant, string pageContentText)
    {
        using var changeTenant = _currentTenant.Change(tenant?.Id, tenant?.Name);

        var homePage = await _pageManager.GetHomePageAsync();

        if (homePage is not null)
        {
            return;
        }

        homePage = await _pageManager.CreateAsync("Home", "home-page", pageContentText);

        await _pageRepository.InsertAsync(homePage, true);

        await _pageManager.SetHomePageAsync(homePage);
    }

    [UnitOfWork]
    protected virtual async Task<Tenant> GetOrCreateDemoTenantAsync()
    {
        var demoTenant = await _tenantRepository.FindByNameAsync("Demo");

        if (demoTenant is not null)
        {
            return demoTenant;
        }

        return await _tenantRepository.InsertAsync(await _tenantManager.CreateAsync("Demo"), true);
    }
}