using System.ComponentModel.DataAnnotations;

namespace Authentication.Dtos.User;

public class UserUpdateDtos
{
    [Required] public int Id { get; set; }

    public string? Username { get; set; } // Nullable để cho phép không cập nhật

    public string? Password { get; set; } // Nullable để cho phép không cập nhật

    public int? RoleId { get; set; } // Nullable để cho phép không cập nhật
}