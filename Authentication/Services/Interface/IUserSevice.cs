using Authentication.Dtos.User;

namespace Authentication.Services.Interface;

public interface IUserSevice
{
    Task<IEnumerable<UserResponseDtos>> GetAllUsersAsync();
    Task<UserResponseDtos> GetUserByIdAsync(int id);
    Task<UserResponseDtos> CreateUserAsync(UserCreateDtos userCreateDto);
    Task<UserResponseDtos> UpdateUserAsync(int id, UserUpdateDtos userUpdateDto);
    Task<string> DeleteUserAsync(int id);
}