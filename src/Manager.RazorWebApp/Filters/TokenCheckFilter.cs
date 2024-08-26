using Manager.RazorWebApp.Handlers;
using Manager.RazorWebApp.Models.AccountModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Manager.RazorWebApp.Filters;

public class TokenCheckFilter : IAsyncPageFilter
{
    private readonly AuthorizationHandler _authorizationHandler;
    private readonly HttpClient _httpClient;
    public TokenCheckFilter(AuthorizationHandler authorizationHandler, IHttpClientFactory clientFactory)
    {
        _authorizationHandler = authorizationHandler;
        _httpClient = clientFactory.CreateClient();
    }

    public async Task OnPageHandlerExecutionAsync(PageHandlerExecutingContext context, PageHandlerExecutionDelegate next)
    {
        var refreshToken = context.HttpContext.Request.Cookies["refresh_token"];

        if(string.IsNullOrEmpty(refreshToken))
        {
            context.Result = new RedirectToPageResult("/Auth/Login");
        }
        else
        {
            
            var accessToken = context.HttpContext.Request.Cookies["access_token"];

            if (!string.IsNullOrEmpty(accessToken))
            {
                await next();
            }
            else
            {
                var httpResponse = await _httpClient.GetAsync($"{Endpoints.AccountBase}{Endpoints.Account.RefreshLogin}/{refreshToken}");

                if(!httpResponse.IsSuccessStatusCode)
                {
                    context.Result = new RedirectToPageResult("/Auth/Login");
                }
                else
                {
                    var response = await httpResponse.Content.ReadFromJsonAsync<LoginResponse>();
                    await _authorizationHandler.Authorize(response!);
                    var endpoint = context.HttpContext.Request.Path;
                    context.Result = new RedirectToPageResult(endpoint);
                }
            }
        }

    }

    public async Task OnPageHandlerSelectionAsync(PageHandlerSelectedContext context)
    {
        await Task.CompletedTask;
    }
}
