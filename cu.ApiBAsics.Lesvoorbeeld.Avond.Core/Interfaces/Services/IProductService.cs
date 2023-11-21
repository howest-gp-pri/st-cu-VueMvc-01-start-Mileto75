using cu.ApiBAsics.Lesvoorbeeld.Avond.Core.Entities;
using cu.ApiBAsics.Lesvoorbeeld.Avond.Core.Services.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cu.ApiBAsics.Lesvoorbeeld.Avond.Core.Interfaces.Services
{
    public interface IProductService
    {
        Task<ItemResultModel<Product>> GetAllAsync();
        Task<ItemResultModel<Product>> GetByIdAsync(int id);
        Task<ItemResultModel<Product>> Add(string name, int categoryId,
            decimal price, IEnumerable<int> properties,IFormFile image);
        Task<ItemResultModel<Product>> UpdateAsync(int id,string name, int categoryId,
            decimal price, IEnumerable<int> properties, IFormFile image);
        Task<bool> DeleteAsync(int id);
        Task<ItemResultModel<Product>> GetByCategoryIdAsync(int id);
    }
}
