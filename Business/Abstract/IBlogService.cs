using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBlogService:IGenericService<Blog>
    {
        List<Blog> GetBlogInfo();
        Blog GetBlog(int id);
        List<Blog> GetBlogsById(int id);
    }
}
