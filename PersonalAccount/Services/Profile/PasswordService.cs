using Microsoft.AspNetCore.Identity;
using PersonalAccount.Models.Student;
using PersonalAccount.Repository;

namespace PersonalAccount.Services.Profile;

public class PasswordService(IStudentRepo<StudentAuthModel> authRepo, IPasswordHasher<StudentAuthModel> passwordHasher) : IPasswordService
{
    public async Task<bool> ValidatePasswordAsync(int id, string password)
    {
        var authStudent = await authRepo.GetByIdAsync(id);
        if (authStudent == null) return false;

        var verificationResult = passwordHasher.VerifyHashedPassword(authStudent, authStudent.PasswordHash, password);
        
        return verificationResult == PasswordVerificationResult.Success;
    }

    public async Task UpdatePasswordAsync(int id, string password)
    {
        var authStudent = await authRepo.GetByIdAsync(id);
        if (authStudent == null) return;

        var newHash = passwordHasher.HashPassword(authStudent, password);

        await authRepo.UpdatePasswordHashAsync(id, newHash);
    }
}