using System;
using MediatR;

namespace OnionArc.Application.Features.Products.Queries.GetProduct
{
	public class GetProductQueryRequest : IRequest<GetProductQueryResponse>
	{
        public int Id { get; set; }

    }
}

