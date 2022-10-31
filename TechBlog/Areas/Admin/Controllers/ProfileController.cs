using Business.Abstract;
using Business.Validations;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace TechBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProfileController : Controller
    {
        private readonly IWriterService writerService;

        public ProfileController(IWriterService writerService)
        {
            this.writerService = writerService;
        }

        public IActionResult Update()
        {
            var sessionUser = JsonConvert.DeserializeObject<Writer>(HttpContext.Session.GetString("username"));
            ViewBag.Id = sessionUser.WriterId;
            var user = writerService.Get(sessionUser.WriterId);
            return View(user);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var user = writerService.Get(id);
            ViewData["img"] = user.PhotoUrl;
            return View(user);
        }


        [HttpPost]
        public IActionResult Edit(int id,EditProfileDTO model)
        {
            var user = writerService.Get(id);
            EditProfileValidator validator = new EditProfileValidator();
            ValidationResult result = validator.Validate(model);

            if (model.PhotoUrl != null)
            {
                var extension = Path.GetExtension(model.PhotoUrl.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot/writerImages", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                model.PhotoUrl.CopyTo(stream);
                user.PhotoUrl = newimagename;
            }

            user.Name= model.Name;
            user.Description = model.Description;
            user.Email = model.Email;
            if (!result.IsValid)
            {
                return RedirectToAction("Edit");
            }

            writerService.Update(user);


            return RedirectToAction("Update");
        }


    }
}
