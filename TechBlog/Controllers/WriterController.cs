using Business.Abstract;
using Business.Validations;
using Core.Entity.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace TechBlog.Controllers
{
    [AllowAnonymous]
    public class WriterController : Controller
    {
        private readonly IWriterService _writerService;

        public WriterController(IWriterService writerService)
        {
            _writerService = writerService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Writer writer)
        {
            WriterValidator validationRules = new WriterValidator();
            ValidationResult result = validationRules.Validate(writer);

            if (result.IsValid)
            {
                _writerService.Add(writer);
                return RedirectToAction("Index", "Login");
            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }

            return View(writer);
        }
        
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Writer user)
        {
            AppDbContext c = new AppDbContext();

            var datavalue = c.Writers.FirstOrDefault(x => x.Email == user.Email &&
            x.Password == user.Password);

            if (datavalue != null)
            {
                var claims = new List<Claim>{
                    new Claim(ClaimTypes.Name,user.Email)
                };

                var useridentity = new ClaimsIdentity(claims,"s");

                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(useridentity);

                await HttpContext.SignInAsync(claimsPrincipal);

                HttpContext.Session.SetString("username", JsonConvert.SerializeObject(datavalue));

                return RedirectToAction("Index", "Blog");
            }
            else
            {
                TempData["Fail"] = "Istifadeci adi ve ya shifre yanlishdir";
                return View();
            }
        }
    }
}
