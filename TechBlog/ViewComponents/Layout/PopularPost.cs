using Business.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TechBlog.ViewComponents.Layout
{
    public class PopularPost : ViewComponent
    {
        private readonly IBlogService blogService;

        public PopularPost(IBlogService blogService)
        {
            this.blogService = blogService;
        }

        public IViewComponentResult Invoke()
        {
            var values = blogService.GetBlogInfo();
            return View(values.TakeLast(5));
        }
    }
}
