using Microsoft.AspNetCore.Http;
using pw3_proyecto.Services.Common.CustomExceptions;
using pw3_proyecto.Services.Interfaces;
using System;
using System.IO;

namespace pw3_proyecto.Services
{
    public class ImageService : IImageService
    {
        public void Save(string folderName, string imageName, string webRootPath, IFormFile imageFile)
        {
            folderName = $"img/{folderName}/";

            if (imageFile == null)
                throw new ImageNotSavedException("File is null");

            string fileExtension = Path.GetExtension(imageFile.FileName);

            if (fileExtension == ".jpg" || fileExtension == ".png")
            {
                string fileName = imageName + fileExtension;

                string partialPath = Path.Combine(webRootPath, folderName);
                string fullPath = Path.Combine(partialPath, fileName);

                if (!Directory.Exists(partialPath))
                    Directory.CreateDirectory(partialPath);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }
            }
            else
            {
                throw new ImageNotSavedException("File extension not supported");
            }
        }
    }
}
