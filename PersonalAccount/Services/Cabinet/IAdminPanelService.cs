using PersonalAccount.Models;
using PersonalAccount.Types;

namespace PersonalAccount.Services.Cabinet;

public interface IAdminPanelService
{
    Task<List<AccountModel>> GetAllAccountsAsync(AccountRoles role);
    Task<List<StudentProfileModel>> GetAllStudentProfilesAsync();
    Task<List<TeacherProfileModel>> GetAllTeacherProfilesAsync();
    Task<List<GroupModel>> GetAllGroupsAsync();
    Task<bool> CheckEmailUniqueAsync(string email);
    Task<string> RegisterAccountWithGeneratedPasswordAsync(string email, AccountRoles role);
    Task RegisterStudentProfileForEmailAsync(string email, string fullName);
    Task RegisterTeacherProfileForEmailAsync(string email, string fullName);
    Task AddTeacherGroupDiscipline(int teacherAccountId, int disciplineId, int groupId);
    Task RemoveTeacherGroupDiscipline(int teacherAccountId, int disciplineId, int groupId);
}