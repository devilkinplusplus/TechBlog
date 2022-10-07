using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BlogManager : IGenericService<Blog>, IBlogService
    {
        private readonly IBlogDal blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            this.blogDal = blogDal;
        }

        public void Add(Blog entity)
        {
            blogDal.Add(entity);
        }

        public void Delete(Blog entity)
        {
            blogDal.Delete(entity);
        }

        public Blog Get(int id)
        {
            return blogDal.Get(x => x.BlogId == id);
        }

        public List<Blog> GetAll()
        {
            return blogDal.GetAll();
        }

        public void Update(Blog entity)
        {
            blogDal.Update(entity);
        }
    }
}
