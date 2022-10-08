using Microsoft.AspNetCore.Mvc;

namespace TechBlog.ViewComponents.Layout
{
    public class Footer:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
