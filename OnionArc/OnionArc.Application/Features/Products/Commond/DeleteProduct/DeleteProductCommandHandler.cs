using System;
using MediatR;
using OnionArc.Application.Interfaces;
using OnionArc.Domain.Entities;

namespace OnionArc.Application.Features.Products.Commond.DeleteProduct
{
	public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest>
	{
		public readonly IUnitOfWork unitOfWork;
		public DeleteProductCommandHandler(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

        public async Task Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await unitOfWork.GetReadRepository<Product>().GetAsync(x => x.Id == request.Id);

			await unitOfWork.GetWriteRepository<Product>().HardDeleteAsync(product);

			await unitOfWork.SaveAsync();

        }
    }
}

