namespace Bloggie.Web.Models.ViewMode
{
    public class AddBlogPost
    {
        public string Heading { get; set; }
        public string PageTitle { get; set; }
        public string Content { get; set; }
        public string ShortDescription { get; set; }
        public string FeaturedImageUrl { get; set; }
        public string ImageHandle { get; set; }
        public DateTime PublishedTime { get; set; }
        public string Author { get; set; }
        public bool Visible { get; set; }
    }
}
