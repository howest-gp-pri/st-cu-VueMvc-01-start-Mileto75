using System.ComponentModel.DataAnnotations;

namespace cu.ApiBasics.Lesvoorbeeld.Avond.Api.DTOs.Account
{
    public class LoginRequestDto
    {
        [Required]
        [EmailAddress]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
