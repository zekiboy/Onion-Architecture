using System;
using MediatR;
using OnionArc.Application.Interfaces;
using OnionArc.Domain.Entities;

namespace OnionArc.Application.Features.Products.Commond.CreateProduct
{
	public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest>
	{
		public IUnitOfWork _unitOfWork { get; set; }
		public CreateProductCommandHandler(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

        public async Task Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
			Product product = new(request.productName, request.Description,request.Stock,request.Price);

			await _unitOfWork.GetWriteRepository<Product>().AddAsync(product);

			if(await _unitOfWork.SaveAsync() > 0)
			{
                foreach (var categoryId in request.CategoryIds)
                {
                    await _unitOfWork.GetWriteRepository<ProductCategory>().AddAsync(new()
                    {
                        ProductId = product.Id,
                        CategoryId = categoryId
                    });
                }

                //Bağlantılı tablo oldığu için önce veritabanında bulabilmesi için yukarıdaki ile Product'ı save ediyoruz. O yüzden 2 tane
                await _unitOfWork.SaveAsync();
            }

        }
    }
}

