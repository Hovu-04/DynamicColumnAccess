using System.ComponentModel.DataAnnotations;

namespace Authentication.Dtos.Intern
{
    public class InternCreateDtos
    {
        [Required(ErrorMessage = "Intern name is required.")]
        public string InternName { get; set; }

        [Required(ErrorMessage = "Intern address is required.")]
        public string InternAddress { get; set; }

        public byte[]? ImageData { get; set; } // Nullable if not needed

        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [Required(ErrorMessage = "Intern email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string InternMail { get; set; }

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
}