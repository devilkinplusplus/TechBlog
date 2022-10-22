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
    public class ContactManager : IGenericService<Contact>, IContactService
    {
        private readonly IContactDal contactDal;

        public ContactManager(IContactDal contactDal)
        {
            this.contactDal = contactDal;
        }

        public void Add(Contact entity)
        {
            contactDal.Add(entity);
        }

        public void Delete(Contact entity)
        {
            contactDal.Delete(entity);
        }

        public Contact Get(int id)
        {
            return contactDal.Get(x=>x.ContactId==id);
        }

        public List<Contact> GetAll()
        {
            return contactDal.GetAll();
        }

        public void Update(Contact entity)
        {
            contactDal.Update(entity);
        }
    }
}
