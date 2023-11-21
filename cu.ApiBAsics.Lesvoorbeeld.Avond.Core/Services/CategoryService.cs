using cu.ApiBAsics.Lesvoorbeeld.Avond.Core.Entities;
using cu.ApiBAsics.Lesvoorbeeld.Avond.Core.Interfaces.Repositories;
using cu.ApiBAsics.Lesvoorbeeld.Avond.Core.Interfaces.Services;
using cu.ApiBAsics.Lesvoorbeeld.Avond.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cu.ApiBAsics.Lesvoorbeeld.Avond.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<ItemResultModel<Category>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            if(categories == null)
            {
                return new ItemResultModel<Category>
                {
                    IsSuccess = false,
                    ValidationErrors = new List<ValidationResult> {
                    new ValidationResult("No categories found!")}
                };
            }
            return new ItemResultModel<Category> {
                IsSuccess = true,
                Items = categories
            };
        }
        public async Task<ItemResultModel<Category>> GetByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if(category == null)
            {
                return new ItemResultModel<Category>
                {
                    IsSuccess = false,
                    ValidationErrors= new List<ValidationResult>
                    { new ValidationResult("Category not found!")}
                };
            }
            return new ItemResultModel<Category>
            {
                IsSuccess = true,
                Items = new List<Category> {category }
            };
        }
    }
}
