using Authentication.Dtos.AllowAccess;
using Authentication.Dtos.Roles;

namespace Authentication.Services.Interface;

public interface IAllowAccessService
{
    Task<IEnumerable<AllowAccessResponseDtos>> GetAllAsync();
    Task<AllowAccessResponseDtos> GetByIdAsync(int id);
    Task<AllowAccessResponseDtos> CreateAsync(AllowAccessCreateDtos allowAccessCreateDto);
    Task<AllowAccessResponseDtos> UpdateAsync(int id, AllowAccessUpdateDtos allowAccessUpdateDto);
    Task<string> DeleteAsync(int id);
}