using AspNetCoreHero.ToastNotification.Abstractions;
using Manager.RazorWebApp.ClientServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shared.Models;

namespace Manager.RazorWebApp.Pages.Account;

public class LoginModel(AccountService accountService, INotyfService notyfService) : PageModel
{
    [BindProperty]
    public LoginRequest LoginInput { get; set; }

    public void OnGet()
    {
    }
    public async Task<IActionResult> OnPost()
    {
        if (!ModelState.IsValid)
        {
            notyfService.Error("Invalid model state");
            return Page();
        }

        var result = await accountService.LoginAsync(LoginInput);

        if (!result)
        {
            notyfService.Error("Login failed");
            return Page();
        }

        notyfService.Success("Login success");
        return RedirectToPage("/Index");
    }
}
