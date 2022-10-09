using Microsoft.AspNetCore.Mvc;

namespace TechBlog.ViewComponents.Layout
{
    public class PopularPost : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
