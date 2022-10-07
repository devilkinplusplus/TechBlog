using Microsoft.AspNetCore.Mvc;

namespace TechBlog.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
