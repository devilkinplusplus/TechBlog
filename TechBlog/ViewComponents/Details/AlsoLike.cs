using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TechBlog.ViewComponents.Details
{
    public class AlsoLike:ViewComponent
    {
        private readonly IBlogService blogService;

        public AlsoLike(IBlogService blogService)
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
