using Microsoft.AspNetCore.Mvc;

namespace TechBlog.ViewComponents.Layout
{
    public class Header : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    
    }
}
