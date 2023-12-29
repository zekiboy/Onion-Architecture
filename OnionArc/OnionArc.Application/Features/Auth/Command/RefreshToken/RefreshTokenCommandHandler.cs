using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using OnionArc.Application.Bases;
using OnionArc.Application.Features.Auth.Rules;
using OnionArc.Application.Interfaces;
using OnionArc.Application.Interfaces.Automapper;
using OnionArc.Application.Interfaces.Tokens;
using OnionArc.Domain.Entities;

namespace OnionArc.Application.Features.Auth.Command.RefreshToken
{
	public class RefreshTokenCommandHandler : BaseHandler, IRequestHandler<RefreshTokenCommandRequest, RefreshTokenCommandResponse>
	{
        private readonly UserManager<User> userManager;
        private readonly ITokenService tokenService;
        private readonly AuthRules authRules;

        public RefreshTokenCommandHandler(UserManager<User> userManager, AuthRules authRules , ITokenService tokenService, IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
                                        : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.tokenService = tokenService;
            this.userManager = userManager;
            this.authRules = authRules;
        }

        public async Task<RefreshTokenCommandResponse> Handle(RefreshTokenCommandRequest request, CancellationToken cancellationToken)
        {
            var principal = tokenService.GetPrincipalFromExpiredToken(request.AccessToken);
            string email = principal.FindFirstValue(ClaimTypes.Email);

            User? user = await userManager.FindByEmailAsync(email);

            IList<string> roles = await userManager.GetRolesAsync(user);


            authRules.RefreshTokenShouldNotBeExpired(user.RefreshTokenExpirtyTime);

            JwtSecurityToken newAccessToken = await tokenService.CreateToken(user, roles);
            string newRefreshToken = tokenService.GenerateRefleshToken();

            user.RefreshToken = newRefreshToken;
            await userManager.UpdateAsync(user);

            return new()
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
                RefreshToken = newRefreshToken,
            };
        }
    }
} 

