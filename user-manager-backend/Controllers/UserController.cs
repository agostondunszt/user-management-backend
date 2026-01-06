using Microsoft.AspNetCore.Mvc;
using user_manager_backend.Models;
using user_manager_backend.Models.DTOs;
using user_manager_backend.Services;

namespace user_manager_backend.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    /// <summary>
    /// User lekérdezése ID alapján.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _userService.GetByIdAsync(id);

        if (user != null)
            return Ok(user);

        return NotFound();
    }

    /// <summary>
    /// Összes user lekérdezése (név alapján szűrve).
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<User>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll([FromQuery] string? name)
    {
        var users = await _userService.GetAllAsync(name);
        return Ok(users);
    }

    /// <summary>
    /// User hozzáadása.
    /// </summary>
    /// <param name="userCreateDto"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(User), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] UserCreateDto userCreateDto)
    {
        var newUser = new User
        {
            Name = userCreateDto.Name,
            Age = userCreateDto.Age,
            Gender = userCreateDto.Gender
        };

        var createdUser = await _userService.CreateAsync(newUser);
        return CreatedAtAction(nameof(GetById), new { id = createdUser.Id }, createdUser);
    }

    /// <summary>
    /// User adatainak frissítése.
    /// </summary>
    /// <param name="userUpdateDto"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPut("{id:int}")]
    [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update([FromBody] UserUpdateDto userUpdateDto, int id)
    {
        var updatedUser = await _userService.UpdateAsync(userUpdateDto, id);

        if (updatedUser == null)
            return NotFound();

        return Ok(updatedUser);
    }
    
    /// <summary>
    /// User törlése.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _userService.DeleteAsync(id);

        if (success)
            return NoContent();

        return NotFound();
    }
}