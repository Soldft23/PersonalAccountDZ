using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalAccount.Models;
using PersonalAccount.Services.Profile;
using PersonalAccount.Services.Tokens;
using PersonalAccount.Utils;

namespace PersonalAccount.Controllers;

[Authorize]
public class ProfileController(IStudentProfileService students, IConfirmationTokenService confirmations) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var studentId = User.GetId();
        if (studentId == null) return RedirectToAction("Error", "Home");
        var student = await students.GetByIdAsync(studentId.Value);
        if (student == null) return RedirectToAction("Error", "Home");
        var confirmed = await confirmations.HasConfirmedTokenAsync(studentId.Value);
        
        return View(new StudentProfileViewModel
        {
            FullName = student.FullName,
            Email = student.Email,
            GroupName = student.GroupName,
            PhotoUrl = student.PhotoUrl?.ToString(),
            IsEmailConfirmed = confirmed
        });
    }
    [HttpGet]
    public async Task<IActionResult> Edit() {
        var studentId = User.GetId();
        if (studentId == null) return RedirectToAction("Error", "Home");
        var student = await students.GetByIdAsync(studentId.Value);
        if (student == null) return RedirectToAction("Error", "Home");

        return View(new StudentEditViewModel
        {
            FullName = student.FullName,
            GroupName = student.GroupName,
            PhotoUrl = student.PhotoUrl?.ToString()
        });
    }
    [HttpPost]
    public async Task<IActionResult> Edit(StudentEditViewModel model) {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        
        var studentId = User.GetId();
        if (studentId == null) return RedirectToAction("Error", "Home");
        var student = await students.GetByIdAsync(studentId.Value);
        if (student == null) return RedirectToAction("Error", "Home");
        
        student.FullName = model.FullName;
        student.GroupName = model.GroupName;
        student.PhotoUrl = new Uri(model.PhotoUrl);
        
        await students.UpdateByIdAsync(studentId.Value, student);
        return RedirectToAction("Index");
    }
}