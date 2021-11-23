using mediahub.Entities;
using Microsoft.EntityFrameworkCore;

namespace mediahub.Data
{
    public class ImageDbContext : DbContext
    {
        public DbSet<Image> Images { get; set; }
    
    public ImageDbContext(DbContextOptions options)
        : base(options) { }

    }
}