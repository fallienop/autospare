using AutoSpare.Application.Abstractions.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Infrastructure.Services.Storage
{
    public class FileService : IFileService
    {
        IHostingEnvironment _hostingEnvironment;

        public FileService(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }


        public async void UploadAsync(string fileName, IFormFile file)
        {
            string basePath = Path.Combine(_hostingEnvironment.WebRootPath, "files/images");
            if (!Directory.Exists(basePath))
            {
                Directory.CreateDirectory(basePath);
            }
            string fullPath = Path.Combine(basePath, $"{fileName}{Path.GetExtension(file.FileName)}");
            //fullPath =await RenameSimilarNameAsync(fullPath);
            using FileStream fileStream = new(fullPath, FileMode.Create, FileAccess.ReadWrite, FileShare.None, 1024 * 1024, useAsync: true);
            await file.CopyToAsync(fileStream);
            await fileStream.FlushAsync();
        }
    }
}
