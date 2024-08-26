using Manager.RazorWebApp.AccountModels;
using Manager.RazorWebApp.Constants;
using Manager.RazorWebApp.Handlers;
using Manager.RazorWebApp.Models.AccountModels;
using Microsoft.AspNetCore.Authentication;

namespace Manager.RazorWebApp.ClientServices;

public class AccountService : ServiceBase
{

    private readonly AuthorizationHandler _authorizationHandler;
    public AccountService(IHttpClientFactory clientFactory, IHttpContextAccessor contextAccessor, AuthorizationHandler authorizationHandler) : base(contextAccessor)
    {
        _authorizationHandler = authorizationHandler;
        _httpClient = clientFactory.CreateClient("Account");
    }


    public async Task<bool> LoginAsync(LoginRequest loginInput)
    {
        string url = $"{Endpoints.Account.Login}";
        var httpResponse = await _httpClient.PostAsJsonAsync(url, loginInput);

        if (httpResponse.IsSuccessStatusCode)
        {
            var response = await httpResponse.Content.ReadFromJsonAsync<LoginResponse>();

            await _authorizationHandler.Authorize(response!);
            return true;
        }
        return false;
    }

    public async Task LogoutAsync()
    {
        var refreshToken = _contextAccessor.HttpContext!.Request.Cookies[CookieConst.REFRESH_TOKEN];
        string url = $"{Endpoints.Account.Logout}/{refreshToken}";
        HttpResponseMessage httpResponse = await _httpClient.GetAsync(url);

        if (httpResponse.IsSuccessStatusCode)
        {
            _contextAccessor.HttpContext!.Response.Cookies.Delete(CookieConst.ACCESS_TOKEN);
            _contextAccessor.HttpContext!.Response.Cookies.Delete(CookieConst.REFRESH_TOKEN);
        }
        await _contextAccessor.HttpContext!.SignOutAsync("AuthScheme");
    }

    public async Task<GetProfileResponse> GetProfileAsync(string id)
    {
        await base.AddAuthorizationHeader();
        string url = $"{Endpoints.Account.GetProfile}/{id}";
        var httpResponse = await _httpClient.GetAsync(url);

        if (httpResponse.IsSuccessStatusCode)
        {
            var response = await httpResponse.Content.ReadFromJsonAsync<GetProfileResponse>();
            return response!;
        }
        return new GetProfileResponse();
    }

    public async Task<bool> UploadPictureAsync(UploadPictureRequest uploadPicture)
    {
        await base.AddAuthorizationHeader();
        string url = $"{Endpoints.Account.UploadPhoto}";
        var httpResponse = await _httpClient.PutAsJsonAsync(url, uploadPicture);
        if (httpResponse.IsSuccessStatusCode)
        {
            return true;
        }
        return false;
    }

    public async Task<bool> ChangePasswordAsync(ChangePasswordRequest changePassword)
    {
        await base.AddAuthorizationHeader();
        string url = $"{Endpoints.Account.ChangePassword}";
        var httpResponse = await _httpClient.PutAsJsonAsync("https://localhost:7000/api/auth/admin/changepassword", changePassword);
        if (httpResponse.IsSuccessStatusCode)
        {
            return true;
        }
        return false;
    }



}
