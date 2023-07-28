using AutoMapper;
using Bloggie.Web.Models.Domain;
using Bloggie.Web.Models.ViewMode;
using Bloggie.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Admin.Blogs
{
    public class AddModel : PageModel
    {
        private readonly IBlogPostRepository blogPostRepository;
        private readonly IMapper mapper;

        [BindProperty]
        public AddBlogPost AddBlogPostRequest { get; set; }

        public AddModel(IBlogPostRepository blogPostRepository, IMapper mapper)
        {
            this.blogPostRepository = blogPostRepository;
            this.mapper = mapper;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            //get value with the help of the name tag of the control name = "heading"
            //var head = Request.Form["heading"]
            var blogPost = mapper.Map<BlogPost>(AddBlogPostRequest);
            await blogPostRepository.AddAsync(blogPost);
            return RedirectToPage("/Admin/Blogs/List");

        }
    }
}
