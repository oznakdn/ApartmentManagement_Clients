using Manager.RazorWebApp.SiteModels;

namespace Manager.RazorWebApp.Models.SiteModels;

public class GetSiteDetailResponse
{
    public string SiteId { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public List<BlockResponse> Blocks { get; set; } = new();
}
