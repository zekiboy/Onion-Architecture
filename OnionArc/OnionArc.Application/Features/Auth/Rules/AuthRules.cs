﻿using System;
using OnionArc.Application.Bases;
using OnionArc.Application.Features.Auth.Exceptions;
using OnionArc.Domain.Entities;

namespace OnionArc.Application.Features.Auth.Rules
{
	public class AuthRules : BaseRules
	{
		public Task UserShouldNotBeExist(User? user)
		{
			if (user is not null) throw new UserAlreadyExistException();
			return Task.CompletedTask;
		}

		public Task EmailOrPasswordShouldNotBeInvalid(User? user, bool checkPassword )
		{
			if (user is null || !checkPassword) throw new EmailOrPasswordShouldNotBeInvalidException();
            return Task.CompletedTask;

        }

        public Task RefreshTokenShouldNotBeExpired (DateTime? expiryDate)
        {
            if (expiryDate <= DateTime.Now) throw new RefreshTokenShouldNotBeExpiredException();
            return Task.CompletedTask;

        }

        public Task EmailAddressShouldBeValid(User? user)
        {
            if (user is null) throw new EmailAddressShouldBeValidException();
            return Task.CompletedTask;
        }
    }
}

