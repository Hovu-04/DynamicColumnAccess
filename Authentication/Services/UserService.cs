using System.Security.Cryptography;
using System.Text;
using Authentication.Dtos.User;
using Authentication.Helper;
using Authentication.Models;
using Authentication.Repository.Interface;
using Authentication.Services.Interface;
using AutoMapper;

namespace Authentication.Services;

public class UserService : IUserSevice
{
    private readonly IRepository<User> _usersRepository;
    private readonly IMapper _mapper;


    public UserService(IRepository<User> usersRepository, IMapper mapper)
    {
        _usersRepository = usersRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserResponseDtos>> GetAllUsersAsync()
    {
        var users = await _usersRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<UserResponseDtos>>(users);
    }

    public async Task<UserResponseDtos> GetUserByIdAsync(int id)
    {
        var user = await _usersRepository.GetByIdAsync(id);
        return _mapper.Map<UserResponseDtos>(user);
    }

   

    public async Task<UserResponseDtos> CreateUserAsync(UserCreateDtos userCreateDto)
    {
        var user = _mapper.Map<User>(userCreateDto);
        user.PasswordHash = PasswordEncryption.HashPassword(userCreateDto.Password); // Assuming you have a HashPassword method
        await _usersRepository.AddAsync(user);
        return _mapper.Map<UserResponseDtos>(user);
    }

    public async Task<UserResponseDtos> UpdateUserAsync(int id, UserUpdateDtos userUpdateDto)
    {
        var user = await _usersRepository.GetByIdAsync(id);
        _mapper.Map(userUpdateDto, user);
        await _usersRepository.UpdateAsync(user);
        return _mapper.Map<UserResponseDtos>(user);
    }

    public async Task<string> DeleteUserAsync(int id)
    {
        await _usersRepository.DeleteAsync(id);
        return "User deleted successfully";
    }
}