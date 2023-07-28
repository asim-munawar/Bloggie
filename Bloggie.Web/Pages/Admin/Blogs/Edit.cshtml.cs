using Bloggie.Web.Models.Domain;
using Bloggie.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Admin.Blogs
{
    public class EditModel : PageModel
    {
        private readonly IBlogPostRepository blogPostRepository;

        [BindProperty]
        public BlogPost BlogPost { get; set; } = new BlogPost();

        public EditModel(IBlogPostRepository blogPostRepository)
        {
            this.blogPostRepository = blogPostRepository;
        }
        public async Task OnGet(Guid Id)
        {
            BlogPost = await blogPostRepository.GetAsync(Id);
        }
        public async Task<IActionResult> OnPostEdit()
        {
            var blogpost = await blogPostRepository.UpdateAsync(BlogPost);
            return RedirectToPage("/Admin/Blogs/List");

        }

        public async Task<IActionResult> OnPostDelete()
        {
            var blogpost = await blogPostRepository.DeleteAsync(BlogPost.Id);
            if (blogpost)
            {
                return RedirectToPage("/Admin/Blogs/List");
            }

            return Page();
        }
    }
}
