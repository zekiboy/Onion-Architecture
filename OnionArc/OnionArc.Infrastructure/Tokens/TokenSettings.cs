﻿using System;
namespace OnionArc.Infrastructure.Tokens
{
	public class TokenSettings
	{
        public string Audience { get; set; }

        public string Issuer { get; set; }

        public string Secret { get; set; }

        public int TokenValidityInMinutes { get; set; }

    }
}
    
