using System;
using FluentValidation;

namespace OnionArc.Application.Features.Products.Commond.DeleteProduct
{
	public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommandRequest>
    {
		public DeleteProductCommandValidator()
		{
			RuleFor(x => x.Id)
				.GreaterThan(0);
		}
	}
}

