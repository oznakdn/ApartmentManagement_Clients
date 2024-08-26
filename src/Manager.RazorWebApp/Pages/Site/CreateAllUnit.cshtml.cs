using AspNetCoreHero.ToastNotification.Abstractions;
using Manager.RazorWebApp.ClientServices;
using Manager.RazorWebApp.Models.SiteModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Manager.RazorWebApp.Pages.Site;

public class CreateAllUnitModel(SiteService siteService, INotyfService notyfService) : PageModel
{
    [BindProperty]
    public CreateUnitRequest CreateUnit { get; set; } = new();
    public async Task<IActionResult> OnGetAsync(string blockId)
    {
        //CreateUnit.BlockId = blockId;
        //var result = await siteService.CreateUnitAsync(CreateUnit);
        //if (!result)
        //{
        //    notyfService.Error("Create all unit failed");
        //    return RedirectToPage("/Site/Index");
        //}
        //notyfService.Success("Create all unit success");
        //return RedirectToPage("/Site/Index");

        await Task.CompletedTask;
        return Page();
    }
}
