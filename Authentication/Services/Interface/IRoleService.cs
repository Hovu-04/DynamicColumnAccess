using Authentication.Dtos.Roles;
using Authentication.Dtos.User;

namespace Authentication.Services.Interface;

public interface IRoleService
{
    Task<IEnumerable<RoleResponseDtos>> GetAllRolesAsync();
    Task<RoleResponseDtos> GetRoleByIdAsync(int id);
    Task<RoleResponseDtos> CreateRoleAsync(RoleCreateDtos roleCreateDtos);
    Task<RoleResponseDtos> UpdateRoleAsync(int id, RoleUpdateDtos roleUpdateDtos);
    Task<string> DeleteRoleAsync(int id);
}