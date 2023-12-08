using System;
using MediatR;
using OnionArc.Application.Interfaces;
using OnionArc.Application.Interfaces.Automapper;
using OnionArc.Domain.Entities;

namespace OnionArc.Application.Features.Products.Commond.UpdateProduct
{
	public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest> 
	{

        private readonly IUnitOfWork unitOfWork;
        public IMapper mapper;

        public UpdateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
		}

        public async Task Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
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

        }
    } 
}

