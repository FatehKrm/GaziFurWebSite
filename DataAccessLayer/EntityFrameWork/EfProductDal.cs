using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstruct;
using DataAccessLayer.Context;
using DataAccessLayer.Repository;
using EntityLayer.Concrate;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFrameWork
{
    public class EfProductDal : GenericRepositoryDal<Product>, IProductDal
    {
        private readonly GaziFurContext _gaziFurContext;
        public EfProductDal(GaziFurContext context) : base(context)
        {
            this._gaziFurContext = context;
        }

        public List<Product> GetLastThreeProductsWithColor()
        {
            var lastThreeProducts = _gaziFurContext.Products
                                          .Include(p => p.Color)
                                          .OrderByDescending(p => p.ProductId) // Büyükten küçüğe sırala
                                          .Take(3)                             // İlk 3 ürünü al
                                          .ToList();

            return lastThreeProducts;
        }

        public List<Product> GetAllWithColor()
        {
            // Products tablosundaki tüm ürünleri ve ilişkili Color bilgilerini getiriyoruz
            var productsWithColor = _gaziFurContext.Products
                                            .Include(p => p.Color)
                                            .Include(x => x.Category) // Ürünle ilişkili Color'ı dahil ediyoruz                                            Include
                                            .Include(z => z.ProductImages)
                                            .ToList();              // Veriyi liste olarak alıyoruz

            return productsWithColor;

        }

        public List<Product> GetAllModels()
        {
            var values = _gaziFurContext.Products
                .Include(p => p.ProductImages)
                .Include(x => x.Color)
                .Include(z => z.Category)
                .OrderByDescending(x => x.ProductId)
                .Take(3)
                .ToList();
            return values;
        }

        // Ürünü Tüm özellikleri ile beraber alıyoruz, ( product ) id'si ile birlikte çek 
        public List<Product> GetAllProductDetails(int id)
        {
            var values = _gaziFurContext.Products
                .Where(p => p.ProductId == id)
                .Include(c => c.Category)
                .Include(p => p.ProductImages)
                .Include(x => x.Color)
                .ToList();
            return values;

        }

        public Product GetAllWithoutList(int id)
        {
            var value = _gaziFurContext.Products
                .Where(p => p.ProductId == id)
                .Include(x => x.Category)
                .Include(z => z.Color)
                .FirstOrDefault(); 
            return value;
        }
    }
}
