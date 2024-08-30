using Admin.RazorWebApp.ClientServices;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shared.Models;

namespace Admin.RazorWebApp.Pages.Account;

public class LoginModel(AccountService accountService,INotyfService notyfService) : PageModel
{
    [BindProperty]
    public LoginRequest LoginRequest { get; set; }
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

        var result = await accountService.LoginAsync(LoginRequest);

        if (!result)
        {
            notyfService.Error("Login failed");
            return Page();
        }

        notyfService.Success("Login success");
        return RedirectToPage("/Index");
    }
}
