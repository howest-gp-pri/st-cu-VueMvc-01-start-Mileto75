using cu.ApiBasics.Lesvoorbeeld.Avond.Infrastructure.Data;
using cu.ApiBAsics.Lesvoorbeeld.Avond.Core.Entities;
using cu.ApiBAsics.Lesvoorbeeld.Avond.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cu.ApiBasics.Lesvoorbeeld.Avond.Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public async Task<IEnumerable<Product>> GetByCategoryIdAsync(int id)
        {
            return await _table
                .Include(p => p.Category)
                .Include(p => p.Properties)
                .Where(p => p.CategoryId == id).ToListAsync();
        }

        public override async Task<Product> GetByIdAsync(int id)
        {
            return await _table
                .Include(p => p.Category)
                .Include(p => p.Properties)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public override async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _table
                .Include(p => p.Category)
                .Include(p => p.Properties)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> SearchAsync(string search)
        {
            return await _table
                 .Include(p => p.Category)
                .Include(p => p.Properties)
                .Where(p => p.Name.ToUpper().Contains(search.ToUpper())).ToListAsync();
        }
    }
}
