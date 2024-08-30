using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Shared.Constants;
using System.Net.Http.Headers;

namespace Shared;

public class ClientServiceBase
{
    public HttpClient _httpClient { get; protected set; }
   
    private readonly IHttpContextAccessor _contextAccessor;

    public ClientServiceBase(IHttpContextAccessor contextAccessor)
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
