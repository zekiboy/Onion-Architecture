using System;
using OnionArc.Domain.Common;

namespace OnionArc.Domain.Entities
{
	public class Category : BaseEntity
	{
        public string categoryName { get; set; }

        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}

