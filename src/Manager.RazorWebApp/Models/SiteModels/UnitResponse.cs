namespace Manager.RazorWebApp.Models.SiteModels;

public class UnitResponse
{
    public string Id { get; set; }
    public int UnitNo { get; set; }
    public bool IsEmpty { get; set; }
    public bool HasCar { get; set; }
    public string? ResidentId { get; set; }
}
