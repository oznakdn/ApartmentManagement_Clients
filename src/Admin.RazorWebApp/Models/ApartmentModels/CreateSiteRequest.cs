using System.ComponentModel.DataAnnotations;

namespace Admin.RazorWebApp.Models.ApartmentModels;

public record CreateSiteRequest(string ManagerId, [Required] string Name, [Required] string Address);
