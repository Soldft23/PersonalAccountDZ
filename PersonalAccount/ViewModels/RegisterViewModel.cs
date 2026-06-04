using System.ComponentModel.DataAnnotations;

namespace PersonalAccount.ViewModels;

public class RegisterViewModel : ViewModel
{
    [Required(ErrorMessage = "Name is required")]
    public string FullName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Contact Email is required")]
    [EmailAddress]
    public string ContactEmail { get; set; } = string.Empty;
}