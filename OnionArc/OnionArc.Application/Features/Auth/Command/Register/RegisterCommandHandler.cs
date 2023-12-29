   using System;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using OnionArc.Application.Bases;
using OnionArc.Application.Features.Auth.Rules;
using OnionArc.Application.Interfaces;
using OnionArc.Application.Interfaces.Automapper;
using OnionArc.Domain.Entities;

namespace OnionArc.Application.Features.Auth.Command.Register
{
	public class RegisterCommandHandler : BaseHandler, IRequestHandler<RegisterCommandRequest, Unit> 
	{

        private readonly AuthRules authRules;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;

        public RegisterCommandHandler(AuthRules authRules,UserManager<User> userManager, RoleManager<Role> roleManager ,IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor )
            : base(mapper, unitOfWork, httpContextAccessor)
		{
            this.authRules = authRules;
            this.userManager = userManager;
            this.roleManager = roleManager;
		}

        public async Task<Unit> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {
            await authRules.UserShouldNotBeExist(await userManager.FindByEmailAsync(request.Email));

            User user = mapper.Map<User, RegisterCommandRequest>(request);
            user.UserName = request.Email;

            //iki kişi tarafıdnan aynı işlem çok küçük zaman farkları ile yapıldığını varsyayalım, SecurityStamp bu durumda sorun yaşamamızı engelliyor
            user.SecurityStamp = Guid.NewGuid().ToString();

            IdentityResult result = await userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                if (!await roleManager.RoleExistsAsync("user"))
                    await roleManager.CreateAsync(new Role
                    {
                        Id = Guid.NewGuid(),
                        Name = "user",
                        NormalizedName = "USER",
                        ConcurrencyStamp = Guid.NewGuid().ToString(),
                    });

                await userManager.AddToRoleAsync(user, "user");
            } 

            return Unit.Value;
        }
    }
}

 