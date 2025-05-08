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
    public class ColorManager : IColorService
    {
        private readonly IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public void TAdd(Color entity)
        {
            _colorDal.Add(entity);
        }

        public List<Color> TGetAll()
        {
            return _colorDal.GetAll();
        }

        public Color TGetById(int id)
        {
            return _colorDal.GetById(id);
        }

        public void TRemove(int id)
        {
           _colorDal.Remove(id);
        }

        public void TUpdate(Color entity)
        {
            _colorDal.Update(entity);
        }
    }
}
