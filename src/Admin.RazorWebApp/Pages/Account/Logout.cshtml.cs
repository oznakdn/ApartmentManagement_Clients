using Admin.RazorWebApp.ClientServices;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Admin.RazorWebApp.Pages.Account;

public class LogoutModel(AccountService accountService, INotyfService notyfService) : PageModel
{
    public async Task OnGetAsync()
    {
        await accountService.LogoutAsync();
        notyfService.Success("Logout success");
        Response.Redirect("/Index");
    }
}
