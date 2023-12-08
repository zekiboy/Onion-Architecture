using System;
using OnionArc.Application.Dto;
using OnionArc.Domain.Entities;

namespace OnionArc.Application.Features.Products.Queries.GetAllProducts
{
	public class GetAllProductsQueryResponse
	{
        public string productName { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }

        //buradaki isimlendirme önemli DTO olsa da mapleyebilmesi için kendi ismini koy
        //public List< CategoryDTO> Categories { get; set; }

    }
}

