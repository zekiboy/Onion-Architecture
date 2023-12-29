 using System;
namespace OnionArc.Application.Features.Auth.Command.Login
{
	public class LoginCommandResponse
	{
		public string Token { get; set; }

        public string RefreshToken { get; set; }

        //token's deatline
        public DateTime Expiration { get; set; }

    }
}

