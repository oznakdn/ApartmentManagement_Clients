using Manager.RazorWebApp.Constants;
using Microsoft.AspNetCore.Authentication;
using System.Net.Http.Headers;

namespace Manager.RazorWebApp.ClientServices;

public class ServiceBase
{
    protected HttpClient _httpClient;
    protected readonly IHttpContextAccessor _contextAccessor;
    public ServiceBase(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }

    public virtual async Task AddAuthorizationHeader()
    {
        var token = _contextAccessor.HttpContext!.Request.Cookies[CookieConst.ACCESS_TOKEN];

        if (string.IsNullOrWhiteSpace(token))
        {
            await _contextAccessor.HttpContext.SignOutAsync();
            _contextAccessor.HttpContext.Response.Redirect("/account/login");
            return;
        }

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

    }

}
