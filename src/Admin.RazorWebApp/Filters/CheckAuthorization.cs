using Admin.RazorWebApp.Constants;
using Admin.RazorWebApp.Handlers;
using Admin.RazorWebApp.Models.AccountModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Admin.RazorWebApp.Filters;

public class CheckAuthorization : ActionFilterAttribute, IAsyncAuthorizationFilter
{
    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {

        string? accessToken = context.HttpContext.Request.Cookies[CookieConst.ACCESS_TOKEN];

        if (string.IsNullOrEmpty(accessToken))
        {

            string? refreshToken = context.HttpContext.Request.Cookies[CookieConst.REFRESH_TOKEN];

            if (!string.IsNullOrEmpty(refreshToken))
            {
                var clientService = context.HttpContext.RequestServices.GetRequiredService<HttpClient>();

                string url = $"{Endpoints.Account.RefreshLogin}/{refreshToken}";

                var responseMessage = await clientService.GetAsync(url);


                if (!responseMessage.IsSuccessStatusCode)
                {
                    await context.HttpContext.SignOutAsync("AuthScheme");
                    context.HttpContext.Response.Cookies.Delete(CookieConst.REFRESH_TOKEN);
                    context.Result = new RedirectToPageResult("/Account/Login");
                }
                else
                {
                    var response = await responseMessage.Content.ReadFromJsonAsync<LoginResponse>();

                    var authorizationHandler = context.HttpContext.RequestServices.GetRequiredService<AuthorizationHandler>();

                    await authorizationHandler.Authorize(response);

                    context.Result = new RedirectToPageResult("/Index");
                }

            }
            else
            {
                await context.HttpContext.SignOutAsync("AuthScheme");
                context.Result = new RedirectToPageResult("/Account/Login");
            }

        }

    }
}
