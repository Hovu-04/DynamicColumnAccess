using Authentication.Dtos.Roles;
using Authentication.Dtos.User;
using Authentication.Models;
using Authentication.Repository.Interface;
using Authentication.Services.Interface;
using AutoMapper;

namespace Authentication.Services;

public class RoleService : IRoleService
{
    private readonly IRepository<Role> _roleRepository;
    private readonly IMapper _mapper;

    public RoleService(IRepository<Role> roleRepository, IMapper mapper)
    {
        _roleRepository = roleRepository;
        _mapper = mapper;
    }


    public async Task<IEnumerable<RoleResponseDtos>> GetAllRolesAsync()
    {
        var roles = await _roleRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<RoleResponseDtos>>(roles);
    }

    public async Task<RoleResponseDtos> GetRoleByIdAsync(int id)
    {
        var role = await _roleRepository.GetByIdAsync(id);
        return _mapper.Map<RoleResponseDtos>(role);
    }

    public async Task<RoleResponseDtos> CreateRoleAsync(RoleCreateDtos roleCreateDto)
    {
        // Check if the role already exists
        var existingRole = await _roleRepository.GetAllAsync();
        if (existingRole.Any(r => r.RoleName == roleCreateDto.RoleName))
        {
            throw new InvalidOperationException("Role already exists");
        }

        var role = _mapper.Map<Role>(roleCreateDto);
        await _roleRepository.AddAsync(role);
        return _mapper.Map<RoleResponseDtos>(role);
    }
    public async Task<RoleResponseDtos> UpdateRoleAsync(int id, RoleUpdateDtos roleUpdateDto)
    {
        var role = await _roleRepository.GetByIdAsync(id);
        if (role == null)
        {
            throw new KeyNotFoundException("Role not found");
        }

        _mapper.Map(roleUpdateDto, role);
        await _roleRepository.UpdateAsync(role);
        return _mapper.Map<RoleResponseDtos>(role);
    }

    public async Task<string> DeleteRoleAsync(int id)
    {
        var role = await _roleRepository.GetByIdAsync(id);
        if (role == null)
        {
            throw new KeyNotFoundException("Role not found");
        }

        await _roleRepository.DeleteAsync(id);
        return "Role deleted successfully";
    }
}