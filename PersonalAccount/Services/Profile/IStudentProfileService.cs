using PersonalAccount.Models.Student;

namespace PersonalAccount.Services.Profile;

public interface IStudentProfileService
{
    Task<StudentModel?> GetByIdAsync(int id);
    Task UpdateByIdAsync(int id, StudentModel student);
}