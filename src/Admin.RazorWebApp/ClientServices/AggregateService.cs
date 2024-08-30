using Admin.RazorWebApp.Models.ApartmentModels;
using Shared;

namespace Admin.RazorWebApp.ClientServices;

public class AggregateService : ClientServiceBase
{
    public AggregateService(IHttpContextAccessor contextAccessor , IHttpClientFactory clientFactory) : base(contextAccessor)
    {
        _httpClient = clientFactory.CreateClient("Aggregator");
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
