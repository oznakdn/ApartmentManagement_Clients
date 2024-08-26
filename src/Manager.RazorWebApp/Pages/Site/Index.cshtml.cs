using AspNetCoreHero.ToastNotification.Abstractions;
using Manager.RazorWebApp.ClientServices;
using Manager.RazorWebApp.Models.SiteModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Manager.RazorWebApp.Pages.Site;

public class IndexModel(SiteService siteService, INotyfService notyfService) : PageModel
{
    [BindProperty]
    public GetSiteDetailResponse SiteDetail { get; set; } = new();

    [BindProperty]
    public CreateBlockRequest CreateBlock { get; set; } = new();

    public async Task OnGetAsync()
    {
        var managerId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
        SiteDetail = await siteService.GetSiteDetailAsync(managerId);
        CreateBlock.SiteId = SiteDetail.SiteId;
    }

    //public async Task<IActionResult> OnPostAsync()
    //{
    //    var result = await siteService.CreateBlockAsync(CreateBlock);

    //    if (!result)
    //    {
    //        notyfService.Error("Create block failed");
    //    }

    //    notyfService.Success("Create block success");
    //    return RedirectToPage("/Site/Index");
    //}
}
