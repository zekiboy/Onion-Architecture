using System;
using MediatR;

namespace OnionArc.Application.Features.Auth.Command.RefreshToken
{
	public class RefreshTokenCommandRequest : IRequest<RefreshTokenCommandResponse>
	{
		public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}

