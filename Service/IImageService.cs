using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using mediahub.Entities;

namespace mediahub.Service
{
    public interface IImageService
    {
    Task<(bool IsSuccess, Exception Exception)> CreateImagesAsync(Image images);
    Task<Image> GetImageAsync(Guid id);
    Task<List<Image>> GetImagesAsync(string title,string altext,string contentType);
    Task<bool> ImageExistsAsync(Guid id);
     Task<(bool IsSuccess, Exception Exception)> DeleteAsync(Guid id);
    }
}