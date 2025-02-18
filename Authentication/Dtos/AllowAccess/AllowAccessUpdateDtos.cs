using System.ComponentModel.DataAnnotations;

namespace Authentication.Dtos.AllowAccess;

public class AllowAccessUpdateDtos
{
    [Required]
    public int Id { get; set; }

    public int? RoleId { get; set; } 

    [MaxLength(100)]
    public string? TableName { get; set; }

    public string? AccessProperties { get; set; }
}