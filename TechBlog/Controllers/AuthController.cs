using Core.Entity.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TechBlog.Controllers
{
	public class AuthController : Controller
	{
		private readonly UserManager<User> _userManager;
		private readonly SignInManager<User> _signInManager;
		public AuthController(UserManager<User> userManager, SignInManager<User> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(LoginDTO model)
		{
			var data = await _userManager.FindByEmailAsync(model.Email);
			if (data == null)
				return View();

			var result = await _signInManager.PasswordSignInAsync(data, model.Password, false, false);

			if (result.Succeeded)
			{
				return RedirectToAction("Index", "Blog");
			}

			return View();
		}

		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Register(RegisterDTO model)
		{
			var data = await _userManager.FindByEmailAsync(model.Email);
			if (data != null)
				return View(model);

			User newUser = new()
			{
				UserName = model.Email,
				FirstName = model.FirstName,
				LastName = model.LastName,
				Email = model.Email,
				PhotoURL = "image.png"
			};
			var identityResult = await _userManager.CreateAsync(newUser, model.Password);

			if (identityResult.Succeeded)
			{
				return RedirectToAction(nameof(Index));
			}
			foreach (var error in identityResult.Errors)
			{
				ModelState.AddModelError("", error.Description);
			}

			return View(model);
		}
	}
}
