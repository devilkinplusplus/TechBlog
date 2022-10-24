using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class CommentDal : EfEntityRepository<Comment, AppDbContext>, ICommentDal
    {
        AppDbContext dbContext = new AppDbContext();
        public List<Comment> GetComments(int id)
        {
            return dbContext.Comments.Where(x=>x.BlogId==id).Include(x=>x.Writer).ToList(); 
        }
    }
}
