using Microsoft.AspNetCore.Mvc;

namespace TechBlog.ViewComponents.Index
{
    public class RecentViews:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
