using System.ComponentModel.DataAnnotations;

namespace Authentication.Models;

public class User
{
    [Key]
    public int Id { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public int RoleId { get; set; }
}