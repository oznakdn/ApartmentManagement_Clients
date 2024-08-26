using AspNetCoreHero.ToastNotification.Abstractions;
using Manager.RazorWebApp.AccountModels;
using Manager.RazorWebApp.ClientServices;
using Manager.RazorWebApp.Models.AccountModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Manager.RazorWebApp.Pages.Account;

public class ProfileModel(AccountService accountService, INotyfService notyfService) : PageModel
{
    [BindProperty]
    public GetProfileResponse Profile { get; set; } = new();

    [BindProperty]
    public UploadPictureRequest UploadPicture { get; set; } = new();

    [BindProperty]
    public ChangePasswordRequest ChangePassword { get; set; } = new();

    public async Task OnGetAsync()
    {
        var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        UploadPicture.Id = id;
        Profile = await accountService.GetProfileAsync(id!);

    }

    //public async Task<IActionResult> OnPostEditProfile()
    //{
    //    var result = await accountService.UpdateProfileAsync(Profile);
    //    if (result)
    //    {
    //        notyfService.Success("Update success");
    //        return RedirectToPage("/Auth/Profile");
    //    }

    //    notyfService.Error("Update failed");
    //    return Page();
    //}

    public async Task<IActionResult> OnPostUploadPicture(IFormFile file)
    {

        if (file is null)
        {
            notyfService.Error("Please select a file");
            return RedirectToPage("/Auth/Profile");
        }

        UploadPicture.PicturePath = $"{UploadPicture.Id}-{file.FileName}";
        var result = await accountService.UploadPictureAsync(UploadPicture);
        if (result)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "ProfilePictures", UploadPicture.PicturePath);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            notyfService.Success("Update success");
            return RedirectToPage("/Auth/Profile");
        }

        notyfService.Error("Update failed");
        return Page();
    }

    public async Task<IActionResult> OnPostChangePassword()
    {

        if(ChangePassword.NewPassword != ChangePassword.ConfirmNewPassword)
        {
            notyfService.Error("Confirm password not match");
            return RedirectToPage("/Auth/Profile");
        }

        if(string.IsNullOrWhiteSpace(ChangePassword.CurrentPassword) || string.IsNullOrWhiteSpace(ChangePassword.NewPassword) || string.IsNullOrWhiteSpace(ChangePassword.ConfirmNewPassword))
        {
            notyfService.Error("Please enter all field");
            return RedirectToPage("/Auth/Profile");
        }
        
        string email = User.FindFirst(ClaimTypes.Email)!.Value;
        ChangePassword.Email = email;
        var result = await accountService.ChangePasswordAsync(ChangePassword);
        if (result)
        {
            notyfService.Success("Password changed success");
            return RedirectToPage("/Auth/Login");
        }

        notyfService.Error("Change failed");
        return RedirectToPage("/Auth/Profile");
    }




}
