using System;
using OnionArc.Domain.Common;

namespace OnionArc.Domain.Entities
{
	public class ProductCategory : IBaseEntity
	{
        public int ProductId { get; set; }

        public int CategoryId { get; set; }

        public Product Product { get; set; }

        public Category Category { get; set; }

    }
}

