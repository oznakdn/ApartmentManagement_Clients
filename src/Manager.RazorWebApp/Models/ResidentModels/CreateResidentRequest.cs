namespace Manager.RazorWebApp.Models.ResidentModels;

public class CreateResidentRequest
{
    public string? UnitId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; } = string.Empty;
}
