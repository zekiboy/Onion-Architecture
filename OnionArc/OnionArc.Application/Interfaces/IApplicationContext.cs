using System;
using System.Collections.Generic;
using OnionArc.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace OnionArc.Application.Interfaces
{
	public interface IApplicationContext
    {

        DbSet<Product> Products { get; set; }
        DbSet<Category> Categories { get; set; }

    }
}

