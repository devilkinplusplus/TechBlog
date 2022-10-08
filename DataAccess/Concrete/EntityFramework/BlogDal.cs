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
    public class BlogDal : EfEntityRepository<Blog, AppDbContext>, IBlogDal
    {
        AppDbContext dbContext=new AppDbContext();
        public List<Blog> GetBlogInfo()
        {
            return dbContext.Blogs.Include(x=>x.Category).Include(x=>x.Writer).ToList();
        }
    }
}
