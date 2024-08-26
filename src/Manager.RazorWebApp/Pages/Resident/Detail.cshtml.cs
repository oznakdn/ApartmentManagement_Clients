using Manager.RazorWebApp.ClientServices;
using Manager.RazorWebApp.Models.ResidentModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Manager.RazorWebApp.Pages.Resident;

public class DetailModel(ResidentService residentService) : PageModel
{
    [BindProperty]
    public GetResidentsResponse Resident { get; set; } = new();

    public async Task OnGetAsync(string id)
    {
        //Resident = await residentService.GetResidentAsync(id);
        await Task.CompletedTask;
    }
}
