using cu.ApiBAsics.Lesvoorbeeld.Avond.Core.Entities;
using cu.ApiBAsics.Lesvoorbeeld.Avond.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cu.ApiBAsics.Lesvoorbeeld.Avond.Core.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<ItemResultModel<Category>> GetAllAsync();
        Task<ItemResultModel<Category>> GetByIdAsync(int id);
    }
}
