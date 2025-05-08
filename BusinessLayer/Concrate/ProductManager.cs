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
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetAllWithColor()
        {
           return _productDal.GetAllWithColor();
        }

        public List<Product> GetLastThreeProductsWithColor()
        {
            return _productDal.GetLastThreeProductsWithColor();
        }

        public void TAdd(Product entity)
        {
            _productDal.Add(entity);
        }

        public List<Product> TGetAll()
        {
            return _productDal.GetAll();
        }

        public List<Product> TGetAllModels()
        {
            return _productDal.GetAllModels();
        }

        public List<Product> TGetAllProductDetails(int id)
        {
           return _productDal.GetAllProductDetails(id);
        }

        public Product TGetAllWithoutList(int id)
        {
            return _productDal.GetAllWithoutList(id);
        }

        public Product TGetById(int id)
        {
            return _productDal.GetById(id); 
        }

        public void TRemove(int id)
        {
            _productDal.Remove(id);
        }

        public void TUpdate(Product entity)
        {
            _productDal.Update(entity);
        }
    }
}
