using System;
using Microsoft.EntityFrameworkCore.Storage;
using OnionArc.Domain.Common;

namespace OnionArc.Application.Interfaces
{
	public interface IUnitOfWork : IAsyncDisposable
    {
        IReadRepository<T> GetReadRepository<T>() where T : class, IBaseEntity , new();

        IWriteRepository<T> GetWriteRepository<T>() where T : class, IBaseEntity, new();
        Task<int> SaveAsync();
        int Save();


        //Task<IDbContextTransaction> BeginTransactionAsync();

        //public IProductRepository ProductRepository { get; }
        //public ICategoryRepository CategoryRepository { get; }
    }
}

