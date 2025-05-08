using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrate;

namespace DataAccessLayer.Abstruct
{
    public interface IProductDal : IGenericDal<Product>
    {
        public List<Product> GetLastThreeProductsWithColor();
        public List<Product> GetAllWithColor();
        public List<Product> GetAllModels();
        public List<Product> GetAllProductDetails(int id);
        public Product GetAllWithoutList(int id);
    }
}
