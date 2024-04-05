using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
namespace AutoSpare.Application.Abstractions.Services
{
    public interface IFileService
    {
         void UploadAsync(string fileName,IFormFile file);
        //Task<string> RenameSimilarNameAsync(string oldFileName);
    }
}
