using cu.ApiBAsics.Lesvoorbeeld.Avond.Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cu.ApiBAsics.Lesvoorbeeld.Avond.Core.Services
{
    public class ImageService : IImageService
    {
        private readonly IHostEnvironment _hostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ImageService(IHostEnvironment hostEnvironment,
            IHttpContextAccessor httpContextAccessor)
        {
            _hostEnvironment = hostEnvironment;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<string> AddOrUpdateImageAsync<T>(IFormFile image, string fileName = "")
        {
            //check for update(if filename == "", => add)
            if (fileName == "")
            {
                //generate name for new filename
                fileName = $"{Guid.NewGuid()}{Path.GetExtension(image.FileName)}";
            }

            //generate path on disk (D:/....wwwroot/images/<entity>)
            var pathOnDisk = Path.Combine(_hostEnvironment.ContentRootPath, "wwwroot",
                "images", typeof(T).Name.ToLower());

            //check if directory exists
            if (!Directory.Exists(pathOnDisk))
            {
                Directory.CreateDirectory(pathOnDisk);
            }


            //store file
            var completePathWithFilename = Path.Combine(pathOnDisk, fileName);
            using (FileStream fileStream = new(completePathWithFilename, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }
            //return filename
            return fileName;
        }

        public string GetImageUrl<T>(string image)
        {
            //get the scheme https
            var scheme = _httpContextAccessor.HttpContext.Request.Scheme;
            //get the host localhost:5001
            var host = _httpContextAccessor.HttpContext.Request.Host.Value;
            //get the images folder
            var imageFolder = $"images/{typeof(T).Name.ToLower()}";
            var fullUrl = $"{scheme}://{host}/{imageFolder}/{image}";
            return fullUrl;
        }
    }
}
