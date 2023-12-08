 using System;
using MediatR;

namespace OnionArc.Application.Features.Products.Queries.GetAllProducts
{
	public class GetAllProductsQueryRequest : IRequest<IList<GetAllProductsQueryResponse>>
	{
    } 
}

