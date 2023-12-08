using System;
namespace OnionArc.Application.Features.Products.Queries.GetProduct
{
	public class GetProductQueryResponse
	{
        public int Id { get; set; }
        public string productName { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }
    }
}

