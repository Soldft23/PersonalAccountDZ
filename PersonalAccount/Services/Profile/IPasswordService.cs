namespace PersonalAccount.Services.Profile;

public interface IPasswordService
{
    Task<bool> ValidatePasswordAsync(int id, string password);
    Task UpdatePasswordAsync(int id, string password);
}