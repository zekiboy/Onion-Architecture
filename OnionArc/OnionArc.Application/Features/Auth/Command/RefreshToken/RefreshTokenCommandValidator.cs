using System;
using FluentValidation;

namespace OnionArc.Application.Features.Auth.Command.RefreshToken
{
	public class RefreshTokenCommandValidator : AbstractValidator<RefreshTokenCommandRequest>
    {
		public RefreshTokenCommandValidator()
		{
			RuleFor(x => x.AccessToken).NotEmpty();
            RuleFor(x => x.RefreshToken).NotEmpty();
        }
    }
}

