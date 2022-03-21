using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace miniShop.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double? Price { get; set; }
        public double Discount { get; set; } = 0;
        public int? CategoryId { get; set; }
        public string ImageUrl { get; set; }

    }
}
