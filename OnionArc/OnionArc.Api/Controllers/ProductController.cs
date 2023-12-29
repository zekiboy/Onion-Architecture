using System;
using Microsoft.AspNetCore.Mvc;
using OnionArc.Application.Interfaces;
using OnionArc.Domain.Entities;
using MediatR;
using OnionArc.Application.Features.Products.Queries.GetAllProducts;
using OnionArc.Application.Features.Products.Commond.CreateProduct;
using OnionArc.Application.Features.Products.Commond.UpdateProduct;
using OnionArc.Application.Features.Products.Commond.DeleteProduct;
using OnionArc.Application.Features.Products.Queries.GetProduct;
using Microsoft.AspNetCore.Authorization;

namespace OnionArc.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;


        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllProducts()
        {
            var response = await _mediator.Send(new GetAllProductsQueryRequest());

            return Ok(response);
        }



        //A request without a body must be sent to an "HttpGet" method. That's why I changed the method to "HttpPost"
        [HttpPost]
        public async Task<IActionResult> GetProduct(GetProductQueryRequest request)
        {

            var response = await _mediator.Send(request);

            return Ok(response);
        }


        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommandRequest request)
        {
            await _mediator.Send(request);

            return Ok();
        }


        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommandRequest request)
        {
            await _mediator.Send(request);

            return Ok();
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(DeleteProductCommandRequest request)
        {
            await _mediator.Send(request);

            return Ok();

            //In the example, the HttpPost method was used because only the IsDeleted state was changed. I used HttpDelete
            //Even if data is deleted in a professional project, we do not want to lose it.
        }

    }
}

