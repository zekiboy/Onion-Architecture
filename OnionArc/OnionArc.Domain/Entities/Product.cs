using System;
using OnionArc.Domain.Common;

namespace OnionArc.Domain.Entities
{
	public class Product : BaseEntity
	{
        public Product()
        {

        }

        public Product(string productname, string description, int stock , int price)
        {
            productName = productname;
            Description = description;
            Stock = stock;
            Price = price;
        }

        public string productName { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }

        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}

