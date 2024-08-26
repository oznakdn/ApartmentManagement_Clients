using AspNetCoreHero.ToastNotification.Abstractions;
using Manager.RazorWebApp.ClientServices;
using Manager.RazorWebApp.Models.ResidentModels;
using Manager.RazorWebApp.Models.SiteModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Manager.RazorWebApp.Pages.Unit;

public class DetailModel(SiteService siteService, ResidentService residentService, INotyfService notyfService) : PageModel
{
    [BindProperty]
    public UnitResponse UnitDetail { get; set; }

    [BindProperty]
    public AssignResidentRequest AssignResident { get; set; } = new();

    [BindProperty]
    public List<GetResidentsResponse> Residents { get; set; } = new();

    [BindProperty]
    public CreateResidentRequest CreateResident { get; set; }

    [BindProperty]
    public List<UnitResponse> Units { get; set; } = new();

    public SelectList UnitList { get; set; }

    public SelectList ResidentList { get; set; }

    public async Task OnGetAsync(string id)
    {
        //UnitDetail = await siteService.GetUnitDetailByIdAsync(id);
        //AssignResident.UnitId = id;

        //var residents = await residentService.GetResidentsAsync();
        //Residents = residents.Where(x => x.UnitId == null).ToList();

        //ResidentList = new SelectList(Residents, "Id", "FullName");

        //var units = await siteService.GetUnitsAsync();
        //Units = units.Where(x=>x.ResidentId == null).ToList();
        //UnitList = new SelectList(Units, "Id", "Detail");

        await Task.CompletedTask;
    }

    //public async Task<IActionResult> OnPostAssignResidentAsync()
    //{
    //    var result = await siteService.AssignResidentToUnitAsync(AssignResident);
    //    if (!result)
    //    {
    //        notyfService.Error("Failed to assign resident to unit");
    //        return RedirectToPage("/site/index");

    //    }

    //    notyfService.Success("Resident assigned to unit successfully");
    //    return RedirectToPage("/site/index");
    //}

    //public async Task<IActionResult> OnPostCreateResidentAsync()
    //{
    //    var result = await residentService.CreateResidentAsync(CreateResident);
    //    if (!result)
    //    {
    //        notyfService.Error("Failed to creating resident");
    //        return RedirectToPage("/site/index");
    //    }

    //    notyfService.Success("Resident created successfully");
    //    return RedirectToPage("/site/index");
    //}
}
