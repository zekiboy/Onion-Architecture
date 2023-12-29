using System;
using OnionArc.Application.Bases;

namespace OnionArc.Application.Features.Products.Exceptions
{
	public class ProductTitleMustNotBeSameException : BaseExceptions
	{

		public ProductTitleMustNotBeSameException() : base("Ürün başlığı zaten var!")
		{

		}
	}
}

