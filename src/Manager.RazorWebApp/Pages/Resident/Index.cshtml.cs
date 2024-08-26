using AspNetCoreHero.ToastNotification.Abstractions;
using Manager.RazorWebApp.ClientServices;
using Manager.RazorWebApp.Models.ResidentModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Manager.RazorWebApp.Pages.Resident;

public class IndexModel(ResidentService residentService, INotyfService notyfService) : PageModel
{
    [BindProperty]
    public IEnumerable<GetResidentsResponse> Residents { get; set; } = new List<GetResidentsResponse>();

    [BindProperty]
    public CreateResidentRequest CreateResident { get; set; } = new();

    public async Task OnGetAsync()
    {
        //Residents = await residentService.GetResidentsAsync();
        await Task.CompletedTask;
    }

    //public async Task<IActionResult> OnPostAsync()
    //{
    //    var result = await residentService.CreateResidentAsync(CreateResident);
    //    if(!result)
    //    {
    //        notyfService.Error("Create Resident Failed");
    //        return RedirectToPage("/Resident/Index");

    //    }

    //    notyfService.Success("Create Resident Success");
    //    return RedirectToPage("/Resident/Index");
    //}
}
