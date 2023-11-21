using System.ComponentModel.DataAnnotations;

namespace cu.ApiBasics.Lesvoorbeeld.Avond.Api.DTOs.Account
{
    public class RegisterRequestDto : LoginRequestDto
    {
        [Required]
        [DataType(DataType.Password)]
        public string RepeatPassword { get; set; }
        [Required]
        
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
