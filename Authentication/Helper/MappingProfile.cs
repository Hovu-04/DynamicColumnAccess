using Authentication.Dtos;
using Authentication.Dtos.AllowAccess;
using Authentication.Dtos.Intern;
using Authentication.Dtos.Roles;
using Authentication.Dtos.User;
using Authentication.Models;
using AutoMapper;

namespace Authentication.Helper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Ánh xạ từ UserCreateDtos sang User
        CreateMap<UserCreateDtos, User>()
            .ForMember(dest => dest.PasswordHash, opt => opt.Ignore()); // Nếu bạn xử lý băm mật khẩu ở nơi khác

        // Ánh xạ từ User sang UserResponseDtos
        CreateMap<User, UserResponseDtos>();

        // Ánh xạ từ UserUpdateDtos sang User
        CreateMap<UserUpdateDtos, User>()
            .ForMember(dest => dest.PasswordHash, opt => opt.Ignore()); // Nếu bạn không muốn cập nhật mật khẩu

        // Ánh xạ từ AllowAccessCreateDtos sang AllowAccess
        CreateMap<AllowAccessCreateDtos, AllowAccess>();

        // Ánh xạ từ AllowAccess sang AllowAccessResponseDtos
        CreateMap<AllowAccess, AllowAccessResponseDtos>();

        // Ánh xạ từ AllowAccessUpdateDtos sang AllowAccess
        CreateMap<AllowAccessUpdateDtos, AllowAccess>();

        // Ánh xạ từ RoleCreateDtos sang Role
        CreateMap<RoleCreateDtos, Role>();

        // Ánh xạ từ Role sang RoleResponseDtos
        CreateMap<Role, RoleResponseDtos>();

        // Ánh xạ từ RoleUpdateDtos sang Role
        CreateMap<RoleUpdateDtos, Role>();

        CreateMap<InternCreateDtos, Intern>();
        CreateMap<InternUpdateDtos, Intern>();
        CreateMap<Intern, InternResponseDtos>();
    }
}