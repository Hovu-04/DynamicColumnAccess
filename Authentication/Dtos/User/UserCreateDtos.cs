using System.ComponentModel.DataAnnotations;

namespace Authentication.Dtos.User;

public class UserCreateDtos
{
    [Required] public string Username { get; set; }

    [Required]
    public string Password { get; set; }

    [Required] public int RoleId { get; set; }
}