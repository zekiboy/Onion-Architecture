using System;
using MediatR;

namespace OnionArc.Application.Features.Products.Commond.CreateProduct
{
	public class CreateProductCommandRequest : IRequest<Unit>
	{
        //Unit for FluentValidation

        public string productName { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }
        public IList<int> CategoryIds { get; set; }

    }
}

