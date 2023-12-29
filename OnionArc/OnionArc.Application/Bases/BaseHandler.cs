using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using OnionArc.Application.Interfaces;
using OnionArc.Application.Interfaces.Automapper;

namespace OnionArc.Application.Bases
{
	public class BaseHandler
	{
        public readonly IMapper mapper;
        public readonly IUnitOfWork unitOfWork;
        public readonly IHttpContextAccessor httpContextAccessor;
        public readonly string userId;

        public BaseHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.httpContextAccessor = httpContextAccessor;

            //bu satır null kalıyor
            userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}

