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
    public class ProductImageManager : IProductImageService
    {
        private readonly IProductImageDal _productImageDal;

        public ProductImageManager(IProductImageDal productImageDal)
        {
            _productImageDal = productImageDal;
        }

        public void TAdd(ProductImage entity)
        {
            _productImageDal.Add(entity);
        }

        public List<ProductImage> TGetAll()
        {
            return _productImageDal.GetAll();
        }

        public ProductImage TGetById(int id)
        {
            return _productImageDal.GetById(id);
        }

        public void TRemove(int id)
        {
            _productImageDal.Remove(id);
        }

        public void TUpdate(ProductImage entity)
        {
            _productImageDal.Update(entity);
        }
    }
}
