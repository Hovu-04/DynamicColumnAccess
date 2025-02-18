using System.ComponentModel.DataAnnotations;

namespace Authentication.Dtos.Roles;

public class RoleUpdateDtos
{
    [Required]
    public int Id { get; set; } // ID của vai trò cần cập nhật

    [Required]
    [MaxLength(100)] // Giới hạn độ dài tên vai trò
    public string RoleName { get; set; }
}