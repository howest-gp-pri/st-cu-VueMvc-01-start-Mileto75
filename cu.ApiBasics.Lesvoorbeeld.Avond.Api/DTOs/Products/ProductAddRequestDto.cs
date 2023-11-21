using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace cu.ApiBasics.Lesvoorbeeld.Avond.Api.DTOs.Products
{
    public class ProductAddRequestDto
    {
        [Required(ErrorMessage = "Please provide a value for {0}")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please provide a value for {0}")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Please provide a value for {0}")]
        public decimal Price { get; set; }
        public IEnumerable<int> Properties { get; set; }
        public IFormFile Image { get; set; }
    }
}
