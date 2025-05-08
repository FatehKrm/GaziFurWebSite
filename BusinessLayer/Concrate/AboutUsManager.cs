using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstruct;
using DataAccessLayer.Abstruct;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concrate;

namespace BusinessLayer.Concrate
{
    public class AboutUsManager : IAboutService
    {
        private readonly IAboutUsDal _aboutUsDal;

        public AboutUsManager(IAboutUsDal aboutUsDal)
        {
            _aboutUsDal = aboutUsDal;
        }

        public void TAdd(AboutUs entity)
        {
           _aboutUsDal.Add(entity);
        }

        public List<AboutUs> TGetAll()
        {
            return _aboutUsDal.GetAll();
        }

        public AboutUs TGetById(int id)
        {
           return _aboutUsDal.GetById(id);
        }

        public void TRemove(int id)
        {
            _aboutUsDal.Remove(id);
        }

        public void TUpdate(AboutUs entity)
        {
           _aboutUsDal.Update(entity);
        }
    }
}
