using System;
using OnionArc.Application.Bases;

namespace OnionArc.Application.Features.Auth.Exceptions
{
    public class UserAlreadyExistException : BaseExceptions
	{
		public UserAlreadyExistException() : base("Böyle bir kullanıcı zaten var!") {}
	}

}

