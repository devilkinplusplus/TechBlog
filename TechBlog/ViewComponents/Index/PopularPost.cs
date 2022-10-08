using Microsoft.AspNetCore.Mvc;

namespace TechBlog.ViewComponents.Index
{
    public class PopularPost:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
