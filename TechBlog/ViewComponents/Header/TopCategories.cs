using Business.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using TechBlog.ViewModels;

namespace TechBlog.ViewComponents.Header
{
    public class TopCategories:ViewComponent
    {
        private readonly IBlogService blogService;
        private readonly ICategoryService categoryService;
        public TopCategories(IBlogService blogService,ICategoryService categoryService)
        {
            this.blogService = blogService;
            this.categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var values = blogService.GetBlogInfo();
            var categorie = categoryService.GetAll();
            NavbarVM navbarVM = new NavbarVM
            {
                Blogs=values,
                Categories=categorie
            };
            return View(navbarVM);
        }
    }
}
