using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrate
{
    public class AboutUs
    {
        [Key]
        public int AboutUsId { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public string Adress { get; set; }
        public string MapAdress { get; set; }
        public string PhoneNumber { get; set; }
        public string WhatsApp { get; set; }
        public string SocialMedia { get; set; }
        public string Email { get; set; }
    }
}
