using System;
using Microsoft.EntityFrameworkCore.Storage;
using OnionArc.Application.Interfaces;
using OnionArc.Persistence.Context;
using OnionArc.Persistence.Repositories;

namespace OnionArc.Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context; 

        }


        //public async Task<IDbContextTransaction> BeginTransactionAsync() => await _context.Database.BeginTransactionAsync();


        public async ValueTask DisposeAsync() => await _context.DisposeAsync();

        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();


        public int Save() => _context.SaveChanges();

        //Bu iki satır eski projelerde yaptığımız GenericRepository'e karşılık geliyor

        IReadRepository<T> IUnitOfWork.GetReadRepository<T>() => new ReadRepository<T>(_context);

        IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>() => new WriteRepository<T>(_context);


    }
}

