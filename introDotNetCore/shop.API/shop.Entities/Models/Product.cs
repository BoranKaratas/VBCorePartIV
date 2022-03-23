using System;
using System.Collections.Generic;

#nullable disable

namespace shop.Entities
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double? Price { get; set; }
        public double Discount { get; set; }
        public int? CategoryId { get; set; }
        public string ImageUrl { get; set; }

        public virtual Category Category { get; set; }
    }
}
