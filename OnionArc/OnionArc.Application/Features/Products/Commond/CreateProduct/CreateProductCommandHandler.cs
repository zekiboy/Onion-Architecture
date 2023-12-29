using System;
using MediatR;
using Microsoft.AspNetCore.Http;
using OnionArc.Application.Bases;
using OnionArc.Application.Features.Products.Rules;
using OnionArc.Application.Interfaces;
using OnionArc.Application.Interfaces.Automapper;
using OnionArc.Domain.Entities;

namespace OnionArc.Application.Features.Products.Commond.CreateProduct
{
	public class CreateProductCommandHandler : BaseHandler, IRequestHandler<CreateProductCommandRequest, Unit>
	{
        //private readonly IUnitOfWork _unitOfWork { get; set; }  readonly kullanmayı unuttum

        public IUnitOfWork _unitOfWork { get; set; }
        public  ProductRules productRules { get; set; }

        public CreateProductCommandHandler(ProductRules productRules,IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
            : base(mapper, unitOfWork, httpContextAccessor)
		{
            this.productRules = productRules;
		}

        public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            IList<Product> products = await _unitOfWork.GetReadRepository<Product>().GetAllAsync();

            await productRules.ProductTitleMustNotBeSame(products, request.productName);


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

            return Unit.Value;
        }
    }
}

