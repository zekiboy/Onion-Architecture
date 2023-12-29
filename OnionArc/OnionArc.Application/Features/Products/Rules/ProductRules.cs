using System;
using OnionArc.Application.Bases;
using OnionArc.Application.Features.Products.Exceptions;
using OnionArc.Domain.Entities;

namespace OnionArc.Application.Features.Products.Rules
{
	public class ProductRules : BaseRules
    {
		public Task ProductTitleMustNotBeSame(IList<Product> products ,string requestName)
        {
            if (products.Any(x => x.productName == requestName)) throw new ProductTitleMustNotBeSameException();

            return Task.CompletedTask;
        }

    }
}

