using System;
using OnionArc.Application.Interfaces;

namespace OnionArc.Infrastructure
{
	public class EmailService : IEmailService
    {
        public bool Send(string to, string message)
        {
            Console.WriteLine("mail sent");
            return true;
        }
    }
}

