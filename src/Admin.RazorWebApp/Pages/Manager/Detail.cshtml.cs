using Admin.RazorWebApp.ClientServices;
using Admin.RazorWebApp.Models.ManagerModels;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shared.Filters;

namespace Admin.RazorWebApp.Pages.Manager;


[CheckAuthorization]
public class DetailModel(ManagerService managerService, INotyfService notyfService) : PageModel
{
    [BindProperty]
    public GetAllManagersResponse Manager { get; set; } = new();

    public async Task OnGetAsync(string managerId)
    {
        var result = await managerService.GetManagerByIdAsync(managerId);

        if(result is not null)
        Manager = result;
    }

    public async Task<IActionResult> OnPostDeleteAsync(string userId)
    {
        var result = await managerService.DeleteManagerAsync(userId);
        if (!result)
        {
            notyfService.Error("Failed to delete manager");
            return Page();
        }
        notyfService.Success("Manager deleted successfully");
        return RedirectToPage("/Manager/Index");
    }
}
