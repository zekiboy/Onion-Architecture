using System;
using FluentValidation;

namespace OnionArc.Application.Features.Products.Commond.UpdateProduct
{
	public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommandRequest>
	{
		public UpdateProductCommandValidator()
		{
            RuleFor(x => x.Id)
                .GreaterThan(0);

            RuleFor(x => x.productName)
                .NotEmpty()
                .WithName("İsim");


            RuleFor(x => x.Description)
                .NotEmpty()
                .WithName("Açıklama");

            RuleFor(x => x.Price)
                .GreaterThan(0)
                .WithName("Fiyat");

            RuleFor(x => x.Stock)
                .GreaterThanOrEqualTo(0)
                .WithName("Stok");

            RuleFor(x => x.CategoryIds)
                .NotEmpty()
                .Must(categories => categories.Any())
                .WithName("Kategoriler");
        }
	}
}

