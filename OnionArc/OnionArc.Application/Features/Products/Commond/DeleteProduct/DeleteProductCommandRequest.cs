 using System;
using MediatR;

namespace OnionArc.Application.Features.Products.Commond.DeleteProduct
{
	public class DeleteProductCommandRequest : IRequest<Unit>
	{
		public int Id { get; set; }		 
	}
}

