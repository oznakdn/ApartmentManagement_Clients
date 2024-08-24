using Admin.RazorWebApp.ClientServices;
using Admin.RazorWebApp.Filters;
using Admin.RazorWebApp.Models.ApartmentModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Admin.RazorWebApp.Pages.Apartment;

[CheckAuthorization]
public class SiteByIdModel(ApartmentService apartmentService) : PageModel
{
    [BindProperty]
    public GetSiteByIdResponse Site { get; set; } = new();


    public async Task OnGetAsync(string siteId)
    {
        Site = await apartmentService.GetSiteById(siteId);
    }
}
