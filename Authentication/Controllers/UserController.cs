using Authentication.Dtos.User;
using Authentication.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserSevice _userService;

    public UserController(IUserSevice userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserResponseDtos>>> GetAllUser()
    {
        var user = await _userService.GetAllUsersAsync();
        return Ok(user);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<UserResponseDtos>> GetUserById(int id)
    {
        var user = await _userService.GetUserByIdAsync(id);
        return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult<UserResponseDtos>> CreateUser([FromBody] UserCreateDtos userCreateDtos)
    {
        var user = await _userService.CreateUserAsync(userCreateDtos);
        return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<UserResponseDtos>> UpdateUser(int id, [FromBody] UserUpdateDtos userUpdateDtos)
    {
        var user = await _userService.UpdateUserAsync(id, userUpdateDtos);
        return Ok(user);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<string>> DeleteUser(int id)
    {
        var user = await _userService.DeleteUserAsync(id);
        return Ok(user);
    }
}