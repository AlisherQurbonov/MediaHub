using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using mediahub.Data;
using mediahub.Entities;

namespace mediahub.Service
{
    public class ImageService : IImageService
    {
        private readonly ImageDbContext _ctx;

        public ImageService(ImageDbContext context)
        {
            _ctx = context;
        }

        public async Task<(bool IsSuccess, Exception Exception)>
        CreateImagesAsync(Image images)
        {
            try
            {
                await _ctx.Images.AddAsync(images);
                await _ctx.SaveChangesAsync();

                return (true, null);
            }
            catch (Exception e)
            {
                return (false, e);
            }
        }

        public async Task<(bool IsSuccess, Exception Exception)>
        DeleteAsync(Guid id)
        {
            try
            {
                var movie = await GetImageAsync(id);

                if (movie == default(Image))
                {
                    return (false, new Exception("Not found"));
                }

                _ctx.Images.Remove (movie);
                await _ctx.SaveChangesAsync();

                return (true, null);
            }
            catch (Exception e)
            {
                return (false, e);
            }
        }

        public Task<Image> GetImageAsync(Guid id) =>
            _ctx.Images.FirstOrDefaultAsync(i => i.Id == id);

        public async Task<List<Image>>
        GetImagesAsync(
            string title = default(string),
            string altText = default(string),
            string contentType = default(string)
        )
        {
            var tasks = _ctx.Images.AsNoTracking();
            if (title != default(string))
            {
                tasks =
                    tasks
                        .Where(t =>
                            t.Title.ToLower().Equals(title.ToLower()) ||
                            t.Title.ToLower().Contains(title.ToLower()));
            }
            if (title != default(string))
            {
                tasks =
                    tasks
                        .Where(t =>
                            t.AltText.ToLower().Equals(altText.ToLower()));
            }
            if (contentType != default(string))
            {
                tasks =
                    tasks
                        .Where(t =>
                            t.AltText.ToLower().Equals(altText.ToLower()));
            }
            return await tasks.ToListAsync();
        }

        public Task<bool> ImageExistsAsync(Guid id) =>
            _ctx.Images.AnyAsync(i => i.Id == id);
    }
}
