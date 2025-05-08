using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrate
{
    public class ProductImage
    {
        [Key]
        public int ProducrImageId { get; set; }
        public int ProductId { get; set; }
        public string ImageUrl { get; set; }
        public Product product { get; set; }    

    }
}
