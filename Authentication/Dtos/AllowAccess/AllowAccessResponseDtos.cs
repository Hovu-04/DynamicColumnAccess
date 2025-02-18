namespace Authentication.Dtos.AllowAccess;

public class AllowAccessResponseDtos
{
    public int Id { get; set; }
    public int RoleId { get; set; }
    public string TableName { get; set; }
    public string AccessProperties { get; set; }
}