using Shared;

namespace Manager.RazorWebApp.ClientServices;

public class ResidentService : ClientServiceBase
{
    public ResidentService(IHttpClientFactory clientFactory, IHttpContextAccessor contextAccessor) : base(contextAccessor)
    {
    }

    
}
