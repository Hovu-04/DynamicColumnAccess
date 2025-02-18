using Authentication.Dtos.Roles;
using Authentication.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RolesController : ControllerBase
{
    private readonly IRoleService _roleService;

    public RolesController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<RoleResponseDtos>>> GetAllRole()
    {
        var role = await _roleService.GetAllRolesAsync();
        return Ok(role);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<IEnumerable<RoleResponseDtos>>> GetRoleById(int id)
    {
        var role = await _roleService.GetRoleByIdAsync(id);
        return Ok(role);
    }

    [HttpPost]
    public async Task<ActionResult<RoleResponseDtos>> CreateRole([FromBody] RoleCreateDtos roleCreateDtos)
    {
        var role = await _roleService.CreateRoleAsync(roleCreateDtos);
        return CreatedAtAction(nameof(GetRoleById), new { id = role.Id }, role);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<RoleResponseDtos>> UpdateRole(int id,[FromBody] RoleUpdateDtos roleUpdateDtos)
    {
        var role = await _roleService.UpdateRoleAsync(id, roleUpdateDtos);
        return Ok(role);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<string>> DeleteRole(int id)
    {
        var role = await _roleService.DeleteRoleAsync(id);
        return Ok(role);
    }
}