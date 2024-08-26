using Manager.RazorWebApp.Models.SiteModels;

namespace Manager.RazorWebApp.ClientServices;

public class SiteService : ServiceBase
{
    public SiteService(IHttpClientFactory clientFactory, IHttpContextAccessor contextAccessor) : base(contextAccessor)
    {
        _httpClient = clientFactory.CreateClient("Site");
    }

    public async Task<GetSiteDetailResponse> GetSiteDetailAsync(string managerId)
    {
        await base.AddAuthorizationHeader();
        string url = $"{Endpoints.Apartment.GetSiteDetailByManagerId}/{managerId}";
        var httpResponse = await _httpClient.GetAsync(url);

        if (httpResponse.IsSuccessStatusCode)
        {
            var response = await httpResponse.Content.ReadFromJsonAsync<GetSiteDetailResponse>();
            return response!;
        }
        return new GetSiteDetailResponse();
    }

    //public async Task<bool> CreateBlockAsync(CreateBlockRequest createBlock)
    //{
    //    await base.AddAuthorizationHeader();
    //    var httpResponse = await _httpClient.PostAsJsonAsync($"{Endpoints.Apartment.Create}", createBlock);
    //    if (httpResponse.IsSuccessStatusCode)
    //    {
    //        return true;
    //    }
    //    return false;
    //}

    //public async Task<bool> CreateUnitAsync(CreateUnitRequest createUnit)
    //{
    //    await base.AddAuthorizationHeader();
    //    var httpResponse = await _httpClient.PostAsJsonAsync($"{Endpoints.UnitBase}{Endpoints.Unit.CreateAll}", createUnit);
    //    if (httpResponse.IsSuccessStatusCode)
    //    {
    //        return true;
    //    }
    //    return false;
    //}

    //public async Task<IEnumerable<UnitResponse>> GetUnitsAsync()
    //{
    //    await base.AddAuthorizationHeader();
    //    var httpResponse = await _httpClient.GetAsync($"{Endpoints.UnitBase}{Endpoints.Unit.GetAll}");
    //    if (httpResponse.IsSuccessStatusCode)
    //    {
    //        var response = await httpResponse.Content.ReadFromJsonAsync<IEnumerable<UnitResponse>>();
    //        return response!;
    //    }
    //    return Enumerable.Empty<UnitResponse>();
    //}

    //public async Task<UnitResponse> GetUnitDetailByIdAsync(string unitId)
    //{
    //    await base.AddAuthorizationHeader();
    //    var httpResponse = await _httpClient.GetAsync($"{Endpoints.UnitBase}{Endpoints.Unit.GetUnitById}/{unitId}");
    //    if (httpResponse.IsSuccessStatusCode)
    //    {
    //        var response = await httpResponse.Content.ReadFromJsonAsync<UnitResponse>();
    //        return response!;
    //    }
    //    return new UnitResponse();

    //}

    //public async Task<bool> AssignResidentToUnitAsync(AssignResidentRequest assignResident)
    //{
    //    await base.AddAuthorizationHeader();
    //    var httpResponse = await _httpClient.PutAsJsonAsync($"{Endpoints.UnitBase}{Endpoints.Unit.AssignResidentToUnit}", assignResident);
    //    if (httpResponse.IsSuccessStatusCode)
    //    {
    //        return true;
    //    }
    //    return false;
    //}
}
