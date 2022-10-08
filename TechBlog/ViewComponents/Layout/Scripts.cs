using Microsoft.AspNetCore.Mvc;

namespace TechBlog.ViewComponents.Layout
{
    public class Scripts:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
