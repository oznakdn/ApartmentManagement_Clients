using Admin.RazorWebApp.Models.ApartmentModels;
using Shared;

namespace Admin.RazorWebApp.ClientServices;

public class ApartmentService : ClientServiceBase
{
    public ApartmentService(IHttpContextAccessor contextAccessor, IHttpClientFactory clientFactory) : base(contextAccessor)
    {
        _httpClient = clientFactory.CreateClient("Apartment");
    }

    public async Task<bool> CreateSiteAsync(CreateSiteRequest createSite)
    {
        await base.AddAuthorizationHeader();
        string url = $"{Endpoints.Apartment.CreateSite}";
        var httpResponse = await _httpClient.PostAsJsonAsync(url, createSite);

        if (httpResponse.IsSuccessStatusCode)
        {
            return true;
        }
        return false;
    }

    public async Task<IEnumerable<GetAllSiteResponse>> GetAllSiteAsync()
    {
        await base.AddAuthorizationHeader();
        string url = $"{Endpoints.Apartment.GetAllSite}";
        var httpResponse = await _httpClient.GetAsync(url);
        if (httpResponse.IsSuccessStatusCode)
        {
            var response = await httpResponse.Content.ReadFromJsonAsync<IEnumerable<GetAllSiteResponse>>();
            return response!;
        }
        return Enumerable.Empty<GetAllSiteResponse>();
    }

    public async Task<bool> AssignManagerAsync(AssignManagerRequest assignManager)
    {
        await base.AddAuthorizationHeader();
        string url = $"{Endpoints.Apartment.AssignManager}";
        var httpResponse = await _httpClient.PutAsJsonAsync(url, assignManager);
        if (httpResponse.IsSuccessStatusCode)
        {
            return true;
        }
        return false;
    }

    public async Task<GetSiteByIdResponse> GetSiteById(string id)
    {
        await base.AddAuthorizationHeader();
        string url = $"{Endpoints.Apartment.GetSiteById}/{id}";
        var httpResponse = await _httpClient.GetAsync(url);
        if (httpResponse.IsSuccessStatusCode)
        {
            var response = await httpResponse.Content.ReadFromJsonAsync<GetSiteByIdResponse>();
            return response!;
        }

        return null;
    }


    public async Task<bool> DeleteSiteAsync(string id)
    {
        await base.AddAuthorizationHeader();
        string url = $"{Endpoints.Apartment.DeleteSite}/{id}";
        var httpResponse = await _httpClient.DeleteAsync(url);
        if (httpResponse.IsSuccessStatusCode)
        {
            return true;
        }
        return false;
    }

}
