using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrate
{
    public  class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public Color Color { get; set; }
        public int ColorId { get; set; }
        public string Price  { get; set; }
        public string Gender { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        public string Size { get; set; }
        public string? IsFeatured { get; set; }
    }
}
