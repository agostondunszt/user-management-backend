using user_management_backend.Models;

namespace user_management_backend.Services;

public interface IUserService
{
    Task<User?> GetByIdAsync(int id);
    Task<IEnumerable<User>> GetAllAsync(string? name);
}