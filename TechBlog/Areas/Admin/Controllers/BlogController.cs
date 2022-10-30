using Business.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Reflection.Metadata;
using TechBlog.Areas.Admin.ViewModels;
using Entities.Concrete;
using Entities.DTOs;
using Business.Validations;
using FluentValidation.Results;

namespace TechBlog.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class BlogController : Controller
    {
        private readonly IBlogService blogService;
        private readonly AppDbContext appDbContext = new AppDbContext();
        public BlogController(IBlogService blogService)
        {
            this.blogService = blogService;
        }

        public IActionResult Index()
        {
            var sessionUser = JsonConvert.DeserializeObject<Writer>(HttpContext.Session.GetString("username"));

            var values = blogService.GetBlogsById(sessionUser.WriterId);
            return View(values);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CategoryValues();
            return View();
        }
        [HttpPost]
        public IActionResult Create(BlogCreateVM model)
        {
            var sessionUser = JsonConvert.DeserializeObject<Writer>(HttpContext.Session.GetString("username"));
            Blog b = new Blog();


            if (model.PhotoUrl != null)
            {
                var extension = Path.GetExtension(model.PhotoUrl.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot/blogImages", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                model.PhotoUrl.CopyTo(stream);
                b.PhotoUrl = newimagename;
            }
            b.Title = model.Title;
            b.Description = model.Description;
            b.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            b.WriterId = sessionUser.WriterId;
            b.CategoryId = model.CategoryId;

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Create");
            }

            blogService.Add(b);
            return RedirectToAction("Index");
        }

        [NonAction]
        private void CategoryValues()
        {
            List<SelectListItem> categoryValues =
                (from x in appDbContext.Categories.ToList()
                 select new SelectListItem
                 {
                     Text = x.Name,
                     Value = x.CategoryId.ToString()
                 }).ToList();
            ViewBag.values = categoryValues;
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = blogService.GetBlog(id);
            CategoryValues();
            ViewData["img"] = data.PhotoUrl;
            UpdateVM updateVM = new()
            {
                Blog = data,
                Category = data.Category
            };
            return View(updateVM);
        }

        [HttpPost]
        public IActionResult Edit(int id, BlogEditVM model)
        {
            var data = blogService.GetBlog(id);

            BlogValidator validations = new BlogValidator();
            ValidationResult result = validations.Validate(model);

            if (model.PhotoUrl != null)
            {
                var extension = Path.GetExtension(model.PhotoUrl.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot/blogImages", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                model.PhotoUrl.CopyTo(stream);
                data.PhotoUrl = newimagename;
            }

            data.Title = model.Title;
            data.Description = model.Description;
            data.CategoryId = model.CategoryId;

            if (!result.IsValid)
            {
                return RedirectToAction("Edit");
            }

            blogService.Update(data);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var data = blogService.Get(id);
            blogService.Delete(data);
            return RedirectToAction(nameof(Index));
        }

    }
}
