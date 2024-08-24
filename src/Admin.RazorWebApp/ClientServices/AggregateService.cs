using Admin.RazorWebApp.Models.ApartmentModels;

namespace Admin.RazorWebApp.ClientServices;

public class AggregateService : ClientServiceBase
{
    public AggregateService(IHttpClientFactory clientFactory, IHttpContextAccessor contextAccessor) : base(clientFactory, contextAccessor)
    {
    }

    public async Task<GetApartmentCountsResponse> GetApartmentCounts()
    {
        await base.AddAuthorizationHeader();
        string url = $"{Endpoints.Aggrigator.GetApartmentCounts}";
        var httpResponse = await _httpClient.GetAsync(url);
        if (httpResponse.IsSuccessStatusCode)
        {
            var response = await httpResponse.Content.ReadFromJsonAsync<GetApartmentCountsResponse>();
            return response!;
        }

        return null;
    }
}
