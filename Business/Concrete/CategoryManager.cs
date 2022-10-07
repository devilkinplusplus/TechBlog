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
    public class CategoryManager : IGenericService<Category>, ICategoryService
    {
        private readonly ICategoryDal categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            this.categoryDal = categoryDal;
        }


        public void Add(Category entity)
        {
            categoryDal.Add(entity);
        }

        public void Delete(Category entity)
        {
            categoryDal.Delete(entity);
        }

        public Category Get(int id)
        {
            return categoryDal.Get(x => x.CategoryId == id);
        }

        public List<Category> GetAll()
        {
            return categoryDal.GetAll();
        }

        public void Update(Category entity)
        {
            categoryDal.Update(entity);
        }
    }
}
