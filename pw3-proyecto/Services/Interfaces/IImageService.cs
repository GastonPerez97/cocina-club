using Microsoft.AspNetCore.Http;

namespace pw3_proyecto.Services.Interfaces
{
    public interface IImageService
    {
        public void Save(string folderName, string imageName, string webRootPath, IFormFile imageFile);
    }
}
