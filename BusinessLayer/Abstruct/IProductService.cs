using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrate;

namespace BusinessLayer.Abstruct
{
    public interface IProductService : IGenericService<Product>
    {
        public List<Product> GetLastThreeProductsWithColor();
        public List<Product> GetAllWithColor();
        public List<Product> TGetAllModels();
        public List<Product> TGetAllProductDetails(int id);
        public Product TGetAllWithoutList(int id);
    }
}
