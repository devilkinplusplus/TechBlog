using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TechBlog.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IActionResult Index()
        {
            var values = _blogService.GetBlogInfo();
            return View(values);
        }
    }
}
