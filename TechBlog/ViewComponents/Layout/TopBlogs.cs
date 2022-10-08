using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TechBlog.ViewComponents.Layout
{
    public class TopBlogs:ViewComponent
    {
        private readonly IBlogService blogService;

        public TopBlogs(IBlogService blogService)
        {
            this.blogService = blogService;
        }

        public IViewComponentResult Invoke()
        {
            var values = blogService.GetBlogInfo();
            return View(values);
        }
    }
}
