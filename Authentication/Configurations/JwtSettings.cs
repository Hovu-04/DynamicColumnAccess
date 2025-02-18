namespace Authentication.Configurations;

public class JwtSettings
{
    public string Key { get; set; }
    public int ExpireMinutes { get; set; }
}