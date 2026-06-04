using Microsoft.EntityFrameworkCore;
using PersonalAccount.Data;
using PersonalAccount.Data.Entities;
using PersonalAccount.Mappers;
using PersonalAccount.Models;
using PersonalAccount.Types;

namespace PersonalAccount.Repositories;

public class AccountRepo(
    AppDbContext ctx,
    IMapper<AccountEntity, AccountModel> mapper
) : Repo<AccountEntity, AccountModel>(ctx, mapper, c => c.Accounts),
    IAccountRepo
{
    public async Task<AccountModel?> GetByEmailAsync(string email) =>
        await GetByAsync(entity => entity.Email == email);

    public async Task<List<AccountModel>> GetAllByRoleAsync(AccountRoles role) =>
        await GetAllByAsync(entity => (entity.Role & role) != 0);
}