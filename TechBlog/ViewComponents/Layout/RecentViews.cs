using Microsoft.AspNetCore.Mvc;

namespace TechBlog.ViewComponents.Layout
{
    public class RecentViews : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
