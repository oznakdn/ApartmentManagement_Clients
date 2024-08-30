using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Shared.Constants;
using System.Net.Http.Headers;

namespace Shared.Handlers;

public class RefrehTokenHandler : DelegatingHandler
{
    private readonly IHttpContextAccessor _contextAccessor;

    public RefrehTokenHandler(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var accessToken = await _contextAccessor.HttpContext!.GetTokenAsync(CookieConst.ACCESS_TOKEN);

        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

        var response = await base.SendAsync(request, cancellationToken);
        if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
        {
            throw new Exception("Access token expired");
        }

        return response;
    }
}
