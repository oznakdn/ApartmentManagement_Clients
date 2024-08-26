namespace Manager.RazorWebApp.ClientServices;

public class ResidentService : ServiceBase
{
    public ResidentService(IHttpClientFactory clientFactory, IHttpContextAccessor contextAccessor) : base(contextAccessor)
    {
    }

    
}
