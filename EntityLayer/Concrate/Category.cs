using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrate
{
    public  class Category
    {
        [Key]
        public int CategorId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string CategoryPhoto { get; set; }
    }
}
