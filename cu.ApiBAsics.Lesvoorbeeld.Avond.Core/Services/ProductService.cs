using cu.ApiBAsics.Lesvoorbeeld.Avond.Core.Entities;
using cu.ApiBAsics.Lesvoorbeeld.Avond.Core.Interfaces.Repositories;
using cu.ApiBAsics.Lesvoorbeeld.Avond.Core.Interfaces.Services;
using cu.ApiBAsics.Lesvoorbeeld.Avond.Core.Services.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cu.ApiBAsics.Lesvoorbeeld.Avond.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IPropertyRepository _propertyRepository;
        private readonly IImageService _imageService;


        public ProductService(IProductRepository productRepository,
            IPropertyRepository propertyRepository,
            IImageService imageService)
        {
            _productRepository = productRepository;
            _propertyRepository = propertyRepository;
            _imageService = imageService;
        }

        public async Task<ItemResultModel<Product>> Add(string name, int categoryId, decimal price, IEnumerable<int> properties, IFormFile image)
        {
            //perform checks(price for example)
            //get the properties
            var allProperties = await _propertyRepository.GetAllAsync();

            //new product
            var newProduct = new Product
            {
                Name = name,
                Price = price,
                CategoryId = categoryId,
                Properties = allProperties.Where(pr => properties.Contains(pr.Id))
                .ToList(),
                Image = await _imageService.AddOrUpdateImageAsync<Product>(image),
            };
            //save to the database
            if(!await _productRepository.AddAsync(newProduct))
            {
                return new ItemResultModel<Product> {
                    IsSuccess = false,
                    ValidationErrors = new List<ValidationResult>{new ValidationResult("Something went wrong!") }
                };
            }
            //save success!
            return new ItemResultModel<Product> {IsSuccess = true};
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var productToDelete = await _productRepository.GetByIdAsync(id);
            if(productToDelete == null)
            {
                return false;
            }
            await _productRepository.DeleteAsync(productToDelete);
            return true;
        }

        public async Task<ItemResultModel<Product>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();
            ItemResultModel<Product> itemResultModel = new ItemResultModel<Product>();
            if(products != null)
            {
                itemResultModel.Items = products;
                itemResultModel.IsSuccess = true;
                return itemResultModel;
            }
            itemResultModel.ValidationErrors = new List<ValidationResult> {
                new ValidationResult("No products found!")
            };
            return itemResultModel;
        }

        public async Task<ItemResultModel<Product>> GetByCategoryIdAsync(int id)
        {
            var products = await _productRepository.GetByCategoryIdAsync(id);
            if(products == null)
            {
                return new ItemResultModel<Product> 
                {
                    ValidationErrors = new List<ValidationResult> { new ValidationResult("No products found!") }
                };
            }
            return new ItemResultModel<Product>
            {
                IsSuccess = true,
                Items = products
            };
        }

        public async Task<ItemResultModel<Product>> GetByIdAsync(int id)
        {
            ItemResultModel<Product> itemResultModel = new ItemResultModel<Product>();
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                itemResultModel.ValidationErrors = new List<ValidationResult>
                {
                    new ValidationResult("No product found!")
                };
                return itemResultModel;
            }
            itemResultModel.Items = new List<Product> { product};
            itemResultModel.IsSuccess = true;
            return itemResultModel;
        }

        public async Task<ItemResultModel<Product>> UpdateAsync(int id, string name, int categoryId, decimal price, IEnumerable<int> properties, IFormFile image)
        {
            //check for null
            //get the product
            var product = await _productRepository.GetByIdAsync(id);
            if(product == null)
            {
                return new ItemResultModel<Product>
                {
                    IsSuccess = false,
                    ValidationErrors = 
                    new List<ValidationResult> {
                    new ValidationResult("Product not found!")
                    }
                };
            }
            //update the product
            var allProperties = await _propertyRepository.GetAllAsync();
            product.Name = name;
            product.CategoryId = categoryId;
            product.Price = price;
            product.Properties =
            _propertyRepository.GetAll().Where(pr => properties.Contains(pr.Id))
            .ToList();
            product.Image = await _imageService.AddOrUpdateImageAsync<Product>(image, product.Image);
            //save to the db
            if(!await _productRepository.UpdateAsync(product))
            {
                return new ItemResultModel<Product>
                {
                    IsSuccess = false,
                    ValidationErrors = new List<ValidationResult>
                    { new ValidationResult("Something went wrong!")}
                };
            }
            //A ok
            return new ItemResultModel<Product> { IsSuccess = true };
        }
    }
}
