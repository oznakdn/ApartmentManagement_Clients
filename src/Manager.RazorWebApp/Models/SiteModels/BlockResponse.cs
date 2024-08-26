using Manager.RazorWebApp.Models.SiteModels;

namespace Manager.RazorWebApp.SiteModels;

public class BlockResponse
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int TotalUnits { get; set; }
    public int AvailableUnits { get; set; }
    public List<UnitResponse> Units { get; set; } = new List<UnitResponse>();

}
