using Business.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TechBlog.Controllers
{
    public class GadgetController : Controller
    {
        private readonly IBlogService blogService;
        public GadgetController(IBlogService blogService)
        {
            this.blogService = blogService;
        }

        public IActionResult Index()
        {
            var values = blogService.GetBlogInfo();

            return View(values);
        }
    }
}
