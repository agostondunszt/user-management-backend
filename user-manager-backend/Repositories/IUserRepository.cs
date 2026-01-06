using user_manager_backend.Models;

namespace user_manager_backend.Repositories;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(int id);
    Task<IEnumerable<User>> GetAllAsync(string? name = null);
    Task<User> CreateAsync(User user);
    Task UpdateAsync(User user);
    Task<bool> DeleteAsync(int id);
}