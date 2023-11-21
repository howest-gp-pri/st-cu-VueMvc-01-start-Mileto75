using System.ComponentModel.DataAnnotations;

namespace cu.ApiBasics.Lesvoorbeeld.Avond.Api.DTOs.Products
{
    public class ProductUpdateRequestDto
    {
        [Required(ErrorMessage = "Please provide a {0}")]
        public int Id { get; set; }
        public ProductAddRequestDto Product { get; set; }
    }
}
