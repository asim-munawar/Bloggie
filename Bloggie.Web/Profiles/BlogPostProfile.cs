using Bloggie.Web.Models.Domain;
using Bloggie.Web.Models.ViewMode;

namespace Bloggie.Web.Profiles
{
    public class BlogPostProfile : AutoMapper.Profile
    {
        public BlogPostProfile()
        {
            CreateMap<AddBlogPost, BlogPost>();
        }
    }
}
