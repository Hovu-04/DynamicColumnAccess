using Authentication.Dtos.AllowAccess;
using Authentication.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AllowAccessController : ControllerBase
{
    private readonly IAllowAccessService _accessService;

    public AllowAccessController(IAllowAccessService accessService)
    {
        _accessService = accessService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AllowAccessResponseDtos>>> GetAllAllow()
    {
        var allow = await _accessService.GetAllAsync();
        return Ok(allow);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<AllowAccessResponseDtos>> GetAllowById(int id)
    {
        var allow = await _accessService.GetByIdAsync(id);
        return Ok(allow);
    }

    [HttpPost]
    public async Task<ActionResult<AllowAccessResponseDtos>> CreateAllow(
        [FromBody] AllowAccessCreateDtos allowAccessCreateDtos)
    {
        var allow = await _accessService.CreateAsync(allowAccessCreateDtos);
        return Ok(allow);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<AllowAccessResponseDtos>> UpdateAllow(int id,
        [FromBody] AllowAccessUpdateDtos accessUpdateDtos)
    {
        var allow = await _accessService.UpdateAsync(id, accessUpdateDtos);
        return Ok(allow);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<string>> DeleteAllow(int id)
    {
        var allow = await _accessService.DeleteAsync(id);
        return Ok(allow);
    }
}