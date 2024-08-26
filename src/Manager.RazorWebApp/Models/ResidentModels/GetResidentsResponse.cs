namespace Manager.RazorWebApp.Models.ResidentModels;

public class GetResidentsResponse
{
    public string Id { get; set; }
    public string? UnitId { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Picture { get; set; } = string.Empty;
}
