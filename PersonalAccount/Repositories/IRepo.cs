using System.Linq.Expressions;
using PersonalAccount.Models;

namespace PersonalAccount.Repositories;

public interface IRepo<TModel> where TModel : Model, new()
{
    // CREATE
    Task AddAsync(TModel model);

    // READ
    Task<TModel?> GetByIdAsync(int id);
    Task<List<TModel>> GetAllAsync();
    Task<bool> AnyAsync();
    
    // DELETE
    Task RemoveByIdAsync(int id);
}