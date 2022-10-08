using Microsoft.AspNetCore.Mvc;

namespace TechBlog.ViewComponents.Layout
{
    public class Head:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
