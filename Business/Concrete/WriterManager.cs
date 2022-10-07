using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class WriterManager : IGenericService<Writer>, IWriterService
    {
        private readonly IWriterDal writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            this.writerDal = writerDal;
        }

        public void Add(Writer entity)
        {
            writerDal.Add(entity);
        }

        public void Delete(Writer entity)
        {
            writerDal.Delete(entity);
        }

        public Writer Get(int id)
        {
            return writerDal.Get(x => x.WriterId == id);
        }

        public List<Writer> GetAll()
        {
            return writerDal.GetAll();
        }

        public void Update(Writer entity)
        {
            writerDal.Update(entity);
        }
    }
}
