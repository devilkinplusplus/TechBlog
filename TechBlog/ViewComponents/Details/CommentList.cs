using Business.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace TechBlog.ViewComponents.Details
{
    public class CommentList:ViewComponent
    {
        private  readonly ICommentService commentService;
        AppDbContext dbContext = new AppDbContext();
        public CommentList(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var values = commentService.GetComments(id);
            ViewBag.CommentCount = dbContext.Comments.Where(x=>x.BlogId==id).Count();
            return View(values);
        }

        
    }
}
