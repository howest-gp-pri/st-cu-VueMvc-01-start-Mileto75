using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cu.ApiBAsics.Lesvoorbeeld.Avond.Core.Interfaces.Services
{
    public interface IImageService
    {
        Task<string> AddOrUpdateImageAsync<T>(IFormFile image, string fileName = "");
        string GetImageUrl<T>(string image);
    }
}
