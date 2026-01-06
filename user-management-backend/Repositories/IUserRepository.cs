using user_management_backend.Models;

namespace user_management_backend.Repositories;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(int id);
    Task<IEnumerable<User>> GetAllAsync();
}