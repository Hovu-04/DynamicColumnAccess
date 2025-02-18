using Authentication.Dtos;
using Authentication.Dtos.Intern;

namespace Authentication.Services.Interface;

public interface IInternService
{
    Task<IEnumerable<InternResponseDtos>> GetAllAsync();
    Task<InternResponseDtos> GetByIdAsync(int id);
    Task<InternResponseDtos> CreateAsync(InternCreateDtos internCreateDtos);
    Task<InternResponseDtos> UpdateAsync(int id, InternUpdateDtos internUpdateDtos);
    Task<string> DeleteAsync(int id);
    Task<List<Dictionary<string, object>>> GetInternInfoByRoleAsync(int roleId);
}