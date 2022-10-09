using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TechBlog.ViewComponents.Details
{
    public class Author:ViewComponent
    {
        private readonly IBlogService blogService;

        public Author(IBlogService blogService)
        {
            this.blogService = blogService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var data = blogService.GetBlog(id);
            return View(data);
        }
    }
}
