using System;
using Microsoft.AspNetCore.Identity;

namespace OnionArc.Domain.Entities
{
	public class User : IdentityUser<Guid> 
    {
        public string FullName { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpirtyTime { get; set; }
    }
}

