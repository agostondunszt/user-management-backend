using user_management_backend.Models;
using user_management_backend.Models.DTOs;
using user_management_backend.Repositories;

namespace user_management_backend.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        return user;
    }

    public async Task<IEnumerable<User>> GetAllAsync(string? name)
    {
        var users = await _userRepository.GetAllAsync(name);
        return users;
    }

    public async Task<User> CreateAsync(User user)
    {
        var createdUser = await _userRepository.CreateAsync(user);
        return createdUser;
    }

    public async Task<User?> UpdateAsync(UserUpdateDto userUpdateDto, int id)
    {
        var userToUpdate = await _userRepository.GetByIdAsync(id);
        if (userToUpdate == null)
            return null;

        userToUpdate.Name = userUpdateDto.Name;
        userToUpdate.Age = userUpdateDto.Age;
        userToUpdate.Gender = userUpdateDto.Gender;

        await _userRepository.UpdateAsync(userToUpdate);
        return userToUpdate;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _userRepository.DeleteAsync(id);
    }
}