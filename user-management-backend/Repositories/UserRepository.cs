using Microsoft.EntityFrameworkCore;
using user_management_backend.Data;
using user_management_backend.Models;

namespace user_management_backend.Repositories;

public class UserRepository : IUserRepository
{
    private readonly UserDbContext _context;

    public UserRepository(UserDbContext context)
    {
        _context = context;
    }
    
    public async Task<User?> GetByIdAsync(int id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        return user;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        var users = await _context.Users.ToListAsync();
        return users;
    }
}