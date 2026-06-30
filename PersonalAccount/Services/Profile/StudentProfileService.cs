using PersonalAccount.Models.Student;
using PersonalAccount.Repository;

namespace PersonalAccount.Services.Profile;

public class StudentProfileService(IStudentRepo<StudentModel> students) : IStudentProfileService
{
    public async Task<StudentModel?> GetByIdAsync(int id) => await students.GetByIdAsync(id);
    public Task UpdateByIdAsync(int id, StudentModel student) => students.UpdateByIdAsync(id, student);
}