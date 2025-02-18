using System.ComponentModel.DataAnnotations;

namespace Authentication.Dtos.Intern;

public class InternUpdateDtos
{
    [Required]
    public int Id { get; set; }

    public string? InternName { get; set; }
    public string? InternAddress { get; set; }
    public byte[]? ImageData { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? InternMail { get; set; }
    public string? University { get; set; }
    public string? CitizenIdentification { get; set; }
    public string? Major { get; set; }
    public string? Cvfile { get; set; }
    public string? TelephoneNum { get; set; }
    public string? ForeignLanguage { get; set; } 
    public string? Introduction { get; set; }
    public string? Note { get; set; }
    public string? JobFields { get; set; } 
}