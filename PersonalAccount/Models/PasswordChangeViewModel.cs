using System.ComponentModel.DataAnnotations;

namespace PersonalAccount.Models;

public class PasswordChangeViewModel
{
    [Required(ErrorMessage = "Old password is required")]
    [DataType(DataType.Password)]
    public string OldPassword { get; set; } = string.Empty;

    [Required(ErrorMessage = "Old password is required")]
    [DataType(DataType.Password)]
    public string NewPassword { get; set; } = string.Empty;

    [Required(ErrorMessage = "Confirm password is required")]
    [DataType(DataType.Password)]
    [Compare("NewPassword", ErrorMessage = "New password dont confirm")]
    public string ConfirmPassword { get; set; } = string.Empty;
}