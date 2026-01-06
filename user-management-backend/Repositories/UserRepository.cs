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

    public async Task<IEnumerable<User>> GetAllAsync(string? name = null)
    {
        var usersQuery = _context.Users.AsQueryable();
        if (!string.IsNullOrWhiteSpace(name))
            usersQuery = usersQuery.Where(u => u.Name.ToLower().Contains(name.ToLower()));
        
        return await usersQuery.ToListAsync();
    }

    public async Task<User> CreateAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }
}