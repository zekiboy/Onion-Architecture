  using System;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnionArc.Application.Interfaces;
using OnionArc.Application.Interfaces.Automapper;
using OnionArc.Domain.Entities;

namespace OnionArc.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, IList<GetAllProductsQueryResponse>>
    {

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAllProductsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IList<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await unitOfWork.GetReadRepository<Product>().GetAllAsync();

            //var products = await unitOfWork.GetReadRepository<Product>().GetAllAsync(
            //    include: x => x.Include(b => b.ProductCategories)
            //    .ThenInclude(b=>b.Category));


            //ProductCategoriesDto diye bir şey yok, ayrıca GetAllAsycn unitOfWorkten köklü bir değişiklik yapmak lazım
            //oyüzden ürünler şimdilik kategori bilgisi olmadan gelsin. Son CQRS olarak ayarla

            //var category = mapper.Map<List<CategoryDTO>, List< Category>>(new List<Category> ());

            var map = mapper.Map<GetAllProductsQueryResponse, Product>(products);

            return map ;
            //throw new Exception("hata mesajı");
        }
    }
}

