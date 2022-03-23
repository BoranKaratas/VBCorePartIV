using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace miniShop.Models
{
    //[Table("Urunler")]
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ürün adı boş olamaz")]
        [MaxLength(150, ErrorMessage = "En fazla 150 karakter olmalıdır")]
        public string Name { get; set; }
        public double? Price { get; set; }
       
        public double Discount { get; set; } = 0;
        public int? CategoryId { get; set; }
        public string ImageUrl { get; set; }
        //Navigation Property
        public Category Category { get; set; }



    }
}
