using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace TechBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly AppDbContext appDbContext;

        public DashboardController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            StatsForDash();
            return View();
        }

        [NonAction]
        private void StatsForDash()
        {
            var sessionUser = JsonConvert.DeserializeObject<Writer>(HttpContext.Session.GetString("username"));
            
            ViewBag.commentPerBlog = appDbContext.Comments.Count(x => x.WriterId == sessionUser.WriterId);

            ViewBag.totalBlogs = appDbContext.Blogs.Count(x => x.WriterId==sessionUser.WriterId);

            ViewBag.topCategory= appDbContext.Blogs.Where(x=>x.WriterId==sessionUser.WriterId).Max(x=>x.Category.Name);

            ViewBag.totalCategories = appDbContext.Categories.Count();
        }
    }
}
