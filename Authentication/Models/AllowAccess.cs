using System.ComponentModel.DataAnnotations;

namespace Authentication.Models;

public class AllowAccess
{
    [Key]
    public int Id { get; set; }
    public int RoleId { get; set; }
    public string TableName { get; set; }
    public string AccessProperties { get; set; }
}