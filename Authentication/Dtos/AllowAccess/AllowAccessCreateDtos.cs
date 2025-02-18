using System.ComponentModel.DataAnnotations;

namespace Authentication.Dtos.AllowAccess;

public class AllowAccessCreateDtos
{
    [Required] public int RoleId { get; set; }

    [Required]
    [MaxLength(100)] // Giới hạn chiều dài tên bảng
    public string TableName { get; set; }

    [Required] public string AccessProperties { get; set; }
}