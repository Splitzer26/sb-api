using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using SBAPI.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBAPI.Application.Services.Interfaces;

namespace SBAPI.Application.Services
{
    public class BlobStorageService : IBlobStorageService
    {
        private readonly BlobServiceClient _blobServiceClient;
        public BlobStorageService(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        public async Task<bool> DeleteFileAsync(string fileName)
        {
            var blobContainer = _blobServiceClient.GetBlobContainerClient("develop");
            var blobClient = blobContainer.GetBlobClient(fileName);
            if (await blobClient.ExistsAsync())
            {
                try
                {
                    await blobClient.DeleteAsync();
                }
                catch
                {
                    throw new ApiException("Ocurrio un error al eliminar el archivo.");
                }
            }
            return true;
        }

        public string GetFile(string imageName)
        {
            var blobContainer = _blobServiceClient.GetBlobContainerClient("develop");

            var blobClient = blobContainer.GetBlobClient(imageName);
            return blobClient.Uri.ToString();
        }

        public async Task UploadFileAsync(IFormFile model)
        {
            var blobContainer = _blobServiceClient.GetBlobContainerClient("develop");

            var blobClient = blobContainer.GetBlobClient(model.FileName);

            var blobHttpHeader = new BlobHttpHeaders { ContentType = model.ContentType };

            try
            {
                await blobClient.UploadAsync(model.OpenReadStream(), new BlobUploadOptions { HttpHeaders = blobHttpHeader });
            }
            catch
            {
                throw new ApiException("Ocurrio un error al cargar el archivo.");
            }
        }
    }
}
