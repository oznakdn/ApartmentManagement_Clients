namespace Manager.RazorWebApp.Models.SiteModels;

public class CreateBlockRequest
{
    public string SiteId { get; set; }
    public string Name { get; set; }
    public int TotalUnits { get; set; }
}
