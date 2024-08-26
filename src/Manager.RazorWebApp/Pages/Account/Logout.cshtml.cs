using AspNetCoreHero.ToastNotification.Abstractions;
using Manager.RazorWebApp.ClientServices;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Manager.RazorWebApp.Pages.Account;

public class LogoutModel(AccountService accountService, INotyfService notyfService) : PageModel
{
    public async Task OnGetAsync()
    {
        await accountService.LogoutAsync();
        notyfService.Success("Logout success");
        Response.Redirect("/Auth/Login");
    }
}
