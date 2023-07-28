using Bloggie.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web.Data
{
    public class BloggieDbContext : DbContext
    {
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Tag> Tagss { get; set; }
        public BloggieDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
    }
}
