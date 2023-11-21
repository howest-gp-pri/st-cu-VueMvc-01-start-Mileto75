using cu.ApiBasics.Lesvoorbeeld.Avond.Api.DTOs.Products;
using cu.ApiBAsics.Lesvoorbeeld.Avond.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace cu.ApiBasics.Lesvoorbeeld.Avond.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProductsController(IProductService productService, IHttpContextAccessor httpContextAccessor)
        {
            _productService = productService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            //get the product
            var product = await _productService.GetByIdAsync(id);
            if(!product.IsSuccess)
            {
                return BadRequest(product.ValidationErrors);
            }
            ProductResponseDto productsResponseDto = new ProductResponseDto
            {
                Name = product.Items.First().Name,
                Category = product.Items.First().Category.Name,
                Properties = product.Items.First().Properties
                .Select(pr => pr.Name),
                Image = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host.Value}/images/product/{product.Items.First().Image}",

            };
            return Ok(productsResponseDto);
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _productService.GetAllAsync();
            if (!products.IsSuccess)
            {
                return BadRequest(products.ValidationErrors);
            }
            var productResponseDto = products.Items.Select(p =>
                new ProductResponseDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Category = p.Category.Name,
                    Price = p.Price,
                    Image = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host.Value}/images/product/{p.Image}",  
                    Properties = p.Properties.Select(p => p.Name)
                });
               
            return Ok(productResponseDto);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromForm]ProductAddRequestDto
            productAddRequestDto)
        {
            //check for model errors
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }
            //check for database errors
            var result = await _productService.Add(
                productAddRequestDto.Name,
                productAddRequestDto.CategoryId,
                productAddRequestDto.Price,
                productAddRequestDto.Properties,
                productAddRequestDto.Image
                );
            if(!result.IsSuccess)
            {
                return BadRequest(result.ValidationErrors);
            }
            //a Ok
            return Ok("Product added!");
        }
        //put to update
        [HttpPut]
        public async Task<IActionResult> Update([FromForm]ProductUpdateRequestDto
            productUpdateRequestDto)
        {
            //check for validation errors
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }
            var result = await _productService.UpdateAsync(
                productUpdateRequestDto.Id,
                productUpdateRequestDto.Product.Name,
                productUpdateRequestDto.Product.CategoryId,
                productUpdateRequestDto.Product.Price,
                productUpdateRequestDto.Product.Properties,
                productUpdateRequestDto.Product.Image
                );
            //check for database errors
            if(!result.IsSuccess)
            {
                return BadRequest(result.ValidationErrors);
            }
            //A ok
            return Ok("Product updated!");
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if(await _productService.DeleteAsync(id))
            {
                return Ok("Product deleted!");
            }
            return BadRequest("Something went wrong! please try again!");
        }
        [HttpGet("category/{id}")]
        public async Task<IActionResult> GetByCategoryId(int id)
        {
            var products = await _productService.GetByCategoryIdAsync(id);
            if(!products.IsSuccess)
            {
                return BadRequest(products.ValidationErrors);
            }
            var productResponseDto = products.Items.Select(p =>
                new ProductResponseDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Category = p.Category.Name,
                    Price = p.Price,
                    Image = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host.Value}/images/products/{p.Image}",
                    Properties = p.Properties.Select(p => p.Name)
                });

            return Ok(productResponseDto);
        }
    }
}
