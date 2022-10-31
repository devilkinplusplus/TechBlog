using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TechBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    [NonController]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var categories = _categoryService.GetAll();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (_categoryService.CheckName(category.Name))
            {
                _categoryService.Add(category);
                return RedirectToAction("Index");
            }
            ViewBag.error = "Name already exist";
            return View();
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var data = _categoryService.Get(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Update(Category category, int id)
        {
            var data = _categoryService.Get(id);

            if (_categoryService.CheckName(category.Name))
            {
                data.Name = category.Name;
                _categoryService.Update(data);
                return RedirectToAction("Index");
            }
            if (category.Name != null)
            {
                ViewBag.error = "Name is already exist";
            }
            return View(category);
        }

        public IActionResult Delete(int id)
        {
            var data = _categoryService.Get(id);
            _categoryService.Delete(data);
            return RedirectToAction("Index");
        }

    }
}
