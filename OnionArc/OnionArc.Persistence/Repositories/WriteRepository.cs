using System;
using Microsoft.EntityFrameworkCore;
using OnionArc.Application.Interfaces;
using OnionArc.Domain.Common;
using OnionArc.Persistence.Context;

namespace OnionArc.Persistence.Repositories
{
	public class WriteRepository<T> : IWriteRepository<T> where T : class , IBaseEntity, new()
	{
        public readonly ApplicationDbContext _context;

        public WriteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        private DbSet<T> Table { get => _context.Set<T>(); }



        public async Task AddAsync(T entity)
        {
            await Table.AddAsync(entity);
        }

        //AddRangeAsync çoğul
        public async Task AddRangeAsync(IList<T> entities)
        {
            await Table.AddRangeAsync(entities);
        }

        //update işlemleri aslımda asenkron gerçekleşmiyor, o yüzden kendi asenkron metodumuzu oluşturacağız
        public async Task<T> UpdateAsync(T entity)
        {
            await Task.Run(() => Table.Update(entity));
            return entity;
        }

        public async Task HardDeleteAsync(T entity)
        {
            await Task.Run(() => Table.Remove(entity));
        }

        public async Task HardDeleteRangeAsync(IList<T> entity)
        {
            await Task.Run(() => Table.RemoveRange(entity));
        }


    }
}

