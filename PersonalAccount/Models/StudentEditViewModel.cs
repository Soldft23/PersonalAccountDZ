using System.ComponentModel.DataAnnotations;

namespace PersonalAccount.Models;

public class StudentEditViewModel
{
    [Required(ErrorMessage = "FullName is required")]
    public string FullName { get; set; } = string.Empty;
    [Required(ErrorMessage = "GropeName is required")]
    public string GroupName { get; set; } = string.Empty;
    public string? PhotoUrl { get; set; }
}