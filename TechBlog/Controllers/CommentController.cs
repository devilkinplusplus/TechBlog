using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TechBlog.ViewModels;

namespace TechBlog.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult CommentList()
        {
            return PartialView();
        }

        [HttpGet]
        public IActionResult CommentAdd()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult CommentAdd(int id,Comment model)
        {
			var sessionUser = JsonConvert.DeserializeObject<Writer>(HttpContext.Session.GetString("username"));

			model.BlogId = id;
            model.WriterId = sessionUser.WriterId;
            var jsonResult = JsonConvert.SerializeObject(model);
            _commentService.Add(model);
            return Json(jsonResult);
        }
    }
}
