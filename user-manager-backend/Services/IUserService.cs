using user_manager_backend.Models;
using user_manager_backend.Models.DTOs;

namespace user_manager_backend.Services;

public interface IUserService
{
    Task<User?> GetByIdAsync(int id);
    Task<IEnumerable<User>> GetAllAsync(string? name);
    Task<User> CreateAsync(User user);
    Task<User?> UpdateAsync(UserUpdateDto userUpdateDto, int id);
    Task<bool> DeleteAsync(int id);
}