using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using OnionArc.Domain.Entities;

namespace OnionArc.Application.Interfaces.Tokens
{
	public interface ITokenService
	{
		Task<JwtSecurityToken> CreateToken(User user, IList<string> roles);

		string GenerateRefleshToken();
		ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token);
	}
}

 