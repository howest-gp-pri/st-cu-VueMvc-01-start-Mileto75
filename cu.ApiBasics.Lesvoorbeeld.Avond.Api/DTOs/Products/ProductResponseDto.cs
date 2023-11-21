using System.Collections.Generic;

namespace cu.ApiBasics.Lesvoorbeeld.Avond.Api.DTOs.Products
{
    public class ProductResponseDto : BaseResponseDto
    {
        public decimal Price { get; set; }
        public string Category { get; set; }
        public IEnumerable<string> Properties { get; set; }
        public string Image { get; set; }
    }
}
