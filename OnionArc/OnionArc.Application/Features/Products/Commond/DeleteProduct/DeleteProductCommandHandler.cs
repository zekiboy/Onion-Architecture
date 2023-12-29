using System;
using MediatR;
using Microsoft.AspNetCore.Http;
using OnionArc.Application.Bases;
using OnionArc.Application.Interfaces;
using OnionArc.Application.Interfaces.Automapper;
using OnionArc.Domain.Entities;

namespace OnionArc.Application.Features.Products.Commond.DeleteProduct
{
	public class DeleteProductCommandHandler : BaseHandler, IRequestHandler<DeleteProductCommandRequest, Unit>
	{
		public DeleteProductCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
            : base(mapper, unitOfWork, httpContextAccessor)
		{
		}

        public async Task<Unit> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await unitOfWork.GetReadRepository<Product>().GetAsync(x => x.Id == request.Id);

			await unitOfWork.GetWriteRepository<Product>().HardDeleteAsync(product);

			await unitOfWork.SaveAsync();

			return Unit.Value;
        }
    }
}

