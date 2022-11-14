using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAPI.Application.Services.Interfaces
{
    public interface IBlobStorageService
    {
        Task UploadFileAsync(IFormFile model);

        string GetFile(string imageName);

        Task<bool> DeleteFileAsync(string fileName);
    }
}
