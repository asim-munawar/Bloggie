using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web.Repositories
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly BloggieDbContext bloggieDbContext;

        public BlogPostRepository(BloggieDbContext bloggieDbContext)
        {
            this.bloggieDbContext = bloggieDbContext;
        }
        public async Task<BlogPost> AddAsync(BlogPost blogPost)
        {
            await bloggieDbContext.BlogPosts.AddAsync(blogPost);
            await bloggieDbContext.SaveChangesAsync();
            return blogPost;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var blogpost = await bloggieDbContext.BlogPosts.FirstOrDefaultAsync(p => p.Id == id);
            if (blogpost != null)
            {
                bloggieDbContext.BlogPosts.Remove(blogpost);
                await bloggieDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<BlogPost> GetAsync(Guid id)
        {
            var blogPost = await bloggieDbContext.BlogPosts.FirstOrDefaultAsync(p => p.Id == id);
            if (blogPost != null)
            {
                return blogPost;
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<BlogPost>> GetBlogPostsAsync()
        {
            var blogPosts = await bloggieDbContext.BlogPosts.ToListAsync();
            if (blogPosts != null && blogPosts.Any())
                return blogPosts;
            else
                return null;
        }

        public async Task<BlogPost> UpdateAsync(BlogPost blogPost)
        {
            var blogpost = await bloggieDbContext.BlogPosts.FirstOrDefaultAsync(p => p.Id == blogPost.Id);
            if (blogpost != null)
            {
                blogpost.Heading = blogPost.Heading;
                blogpost.Author = blogPost.Author;
                blogpost.ShortDescription = blogPost.ShortDescription;
                blogpost.Content = blogPost.Content;
                blogpost.FeaturedImageUrl = blogPost.FeaturedImageUrl;
                blogpost.Heading = blogpost.Heading;
                blogpost.ImageHandle = blogPost.ImageHandle;
                blogpost.PageTitle = blogPost.PageTitle;
                blogpost.PublishedTime = blogPost.PublishedTime;
                blogpost.Visible = blogPost.Visible;
                await bloggieDbContext.SaveChangesAsync();
                return blogpost;
            }
            return null;

        }
    }
}
