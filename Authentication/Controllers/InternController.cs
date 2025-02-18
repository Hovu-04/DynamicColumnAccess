using System.Security.Claims;
using Authentication.Dtos;
        using Authentication.Dtos.Intern;
        using Authentication.Services.Interface;
        using Microsoft.AspNetCore.Mvc;
        
        namespace Authentication.Controllers;
        
        [ApiController]
        [Route("api/[controller]")]
        public class InternController : ControllerBase
        {
            private readonly IInternService _internService;
        
            public InternController(IInternService internService)
            {
                _internService = internService;
            }
            // Lấy thông tin thực tập sinh theo quyền người dùng
            [HttpGet("getinterns")]
            public async Task<IActionResult> GetInterns()
            {
                var userRole = User.FindFirstValue(ClaimTypes.Role);
                if (string.IsNullOrEmpty(userRole))
                {
                    return BadRequest("Role is missing or invalid in the token.");
                }

                int roleId;
                if (!int.TryParse(userRole, out roleId))
                {
                    return BadRequest("Role is not a valid integer.");
                }

                // Lấy thông tin thực tập sinh từ service theo quyền người dùng
                var internInfo = await _internService.GetInternInfoByRoleAsync(roleId);

                // Nếu không có thông tin nào, trả về NotFound
                if (internInfo == null || internInfo.Count == 0)
                {
                    return NotFound("No intern data available for the specified role.");
                }

                return Ok(internInfo);
            }
            [HttpGet]
            public async Task<ActionResult<IEnumerable<InternResponseDtos>>> GetAllInterns()
            {
                var interns = await _internService.GetAllAsync();
                return Ok(interns);
            }
        
            [HttpGet("{id:int}")]
            public async Task<ActionResult<InternResponseDtos>> GetInternById(int id)
            {
                var interns = await _internService.GetByIdAsync(id);
                return Ok(interns);
            }
        
            [HttpPost]
            public async Task<ActionResult<InternResponseDtos>> CreateIntern([FromBody] InternCreateDtos internCreateDtos)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
        
                var interns = await _internService.CreateAsync(internCreateDtos);
                return Ok(interns);
            }
        
            [HttpPut("{id:int}")]
            public async Task<ActionResult<InternResponseDtos>> UpdateIntern(int id, [FromBody] InternUpdateDtos internUpdateDtos)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
        
                var interns = await _internService.UpdateAsync(id, internUpdateDtos);
                return Ok(interns);
            }
        
            [HttpDelete("{id:int}")]
            public async Task<ActionResult<InternResponseDtos>> DeleteIntern(int id)
            {
                var intern = await _internService.DeleteAsync(id);
                return Ok(intern);
            }
        }