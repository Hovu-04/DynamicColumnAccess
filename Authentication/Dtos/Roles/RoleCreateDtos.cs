using System.ComponentModel.DataAnnotations;

namespace Authentication.Dtos.Roles;

public class RoleCreateDtos
{
    [Required]
    [MaxLength(100)] // Giới hạn độ dài tên vai trò
    public string RoleName { get; set; }
}