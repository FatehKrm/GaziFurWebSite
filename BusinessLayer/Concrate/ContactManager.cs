using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstruct;
using DataAccessLayer.Abstruct;
using EntityLayer.Concrate;

namespace BusinessLayer.Concrate
{
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void TAdd(Contact entity)
        {
            _contactDal.Add(entity);
        }

        public List<Contact> TGetAll()
        {
            return _contactDal.GetAll();    
        }

        public Contact TGetById(int id)
        {
            return _contactDal.GetById(id); 
        }

        public void TRemove(int id)
        {
            _contactDal.Remove(id); 
        }

        public void TUpdate(Contact entity)
        {
            _contactDal.Update(entity);
        }
    }
}
