using System;
using MediatR;
using Microsoft.AspNetCore.Http;
using OnionArc.Application.Bases;
using OnionArc.Application.Interfaces;
using OnionArc.Application.Interfaces.Automapper;
using OnionArc.Domain.Entities;

namespace OnionArc.Application.Features.Products.Commond.UpdateProduct
{
	public class UpdateProductCommandHandler : BaseHandler, IRequestHandler<UpdateProductCommandRequest, Unit> 
	{

 

        public UpdateProductCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
            : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<Unit> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await unitOfWork.GetReadRepository<Product>().GetAsync(x => x.Id == request.Id);

            var map = mapper.Map<Product, UpdateProductCommandRequest>(request);

            var productCategories = await unitOfWork.GetReadRepository<ProductCategory>()
                .GetAllAsync(x => x.ProductId == request.Id);

            await unitOfWork.GetWriteRepository<ProductCategory>()
                .HardDeleteRangeAsync(productCategories);

            foreach (var categoryId in request.CategoryIds)
                await unitOfWork.GetWriteRepository<ProductCategory>()
                    .AddAsync(new() {CategoryId = categoryId, ProductId = product.Id  });

            await unitOfWork.GetWriteRepository<Product>().UpdateAsync(map);
            await unitOfWork.SaveAsync();
            //map is going to update

            return Unit.Value;
            //return Unit for Validation

        }
    } 
}

