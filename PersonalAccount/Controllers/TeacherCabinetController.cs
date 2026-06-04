using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalAccount.Constants;
using PersonalAccount.Services.Cabinet;
using PersonalAccount.Services.Tokens;
using PersonalAccount.Utils;
using PersonalAccount.ViewModels;

namespace PersonalAccount.Controllers;

[Authorize(Roles = AccountRoleConstants.Teacher)]
public class TeacherCabinetController(
    ITeacherCabinetService cabinetService,
    IConfirmationTokenService confirmationTokenService
) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var accountId = User.GetId();
        var accountEmail = User.GetEmail();
        if (accountId == null || accountEmail == null) return Forbid();
        var teacherProfile = await cabinetService.GetProfileAsync(accountId.Value);
        if (teacherProfile == null) return RedirectToAction("Error", "Home");
        var emailConfirmed = await confirmationTokenService.HasConfirmedTokenAsync(teacherProfile.AccountId);
        var groupsByDisciplines = await cabinetService.GetGroupsByDisciplineAsync(teacherProfile.AccountId);

        return View(new TeacherCabinetViewModel
        {
            FullName = teacherProfile.FullName,
            PhotoUrl = teacherProfile.PhotoUrl?.ToString(),
            Email = accountEmail,
            IsEmailConfirmed = emailConfirmed,
            DisciplineIdsOrder = groupsByDisciplines.Keys
                .OrderBy(discipline => discipline.Name)
                .Select(discipline => discipline.Id).ToList(),
            Disciplines = groupsByDisciplines.Keys
                .ToDictionary(discipline => discipline.Id, discipline => new TeacherCabinetDisciplineViewModel
                {
                    Name = discipline.Name,
                }),
            GroupsByDisciplines = groupsByDisciplines.ToDictionary(
                groupsByDiscipline => groupsByDiscipline.Key.Id,
                groupsByDiscipline => groupsByDiscipline.Value
                    .Select(group => new TeacherCabinetGroupViewModel
                    {
                        Name = group.Name,
                        ImageUrl = group.ImageUrl?.ToString(),
                    })
                    .ToList())
        });
    }
}