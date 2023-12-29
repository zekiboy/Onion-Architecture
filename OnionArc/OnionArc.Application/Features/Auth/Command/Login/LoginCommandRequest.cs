using System;
using System.ComponentModel;
using MediatR;

namespace OnionArc.Application.Features.Auth.Command.Login
{
	public class LoginCommandRequest : IRequest<LoginCommandResponse>
	{
		[DefaultValue("admin@admin")]
		public string Email { get; set; }

        [DefaultValue("admin123")]
        public string Password { get; set; }
	}
}

