using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop.DTOs.Requests
{
   public class AddProductRequest
    {
        [Required(ErrorMessage ="Ürün adı boş olamaz!")]
        public string Name { get; set; }
        public double? Price { get; set; }
        public double Discount { get; set; } = 0;
        public int? CategoryId { get; set; }
        public string ImageUrl { get; set; }
    }
}
