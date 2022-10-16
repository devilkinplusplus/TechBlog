using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class CategoryDal : EfEntityRepository<Category, AppDbContext>, ICategoryDal
    {
        AppDbContext appDbContext = new AppDbContext();
        public bool CheckName(string name)
        {
            if (name != null)
            {
                var data = appDbContext.Categories.FirstOrDefault(c => c.Name.ToLower() == name.ToLower());
                if (data == null)
                    return true;
            }
            return false;
        }
    }
}
