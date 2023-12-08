using System;
using MediatR;
using OnionArc.Application.Features.Products.Queries.GetAllProducts;
using OnionArc.Application.Interfaces;
using OnionArc.Application.Interfaces.Automapper;
using OnionArc.Domain.Entities;

namespace OnionArc.Application.Features.Products.Queries.GetProduct
{
	public class GetProductQueryHandler : IRequestHandler<GetProductQueryRequest,GetProductQueryResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetProductQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<GetProductQueryResponse> Handle(GetProductQueryRequest request, CancellationToken cancellationToken)
        {
            var product = await unitOfWork.GetReadRepository<Product>().GetAsync(x => x.Id == request.Id);
            var map = mapper.Map<GetProductQueryResponse, Product>(product);
            return map;
        }
    }
}

