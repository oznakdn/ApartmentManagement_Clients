using System.ComponentModel.DataAnnotations;

namespace Manager.RazorWebApp.AccountModels;

public class ChangePasswordRequest
{
    public string Email { get; set; }

    [Required]
    public string CurrentPassword { get; set; }

    [Required]
    public string NewPassword { get; set; }

    [Required]
    [Compare(nameof(NewPassword))]
    public string ConfirmNewPassword { get; set; }

}
