using user_management_backend.Models;
using user_management_backend.Models.DTOs;

namespace user_management_backend.Repositories;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(int id);
    Task<IEnumerable<User>> GetAllAsync(string? name = null);
    Task<User> CreateAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(int id);
}