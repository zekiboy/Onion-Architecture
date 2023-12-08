using System;
namespace OnionArc.Application.Interfaces
{
	public interface IEmailService
	{
        bool Send(string to, string message);

    }
}

