 using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnionArc.Application.Interfaces;
using OnionArc.Domain.Common;
using OnionArc.Persistence.Context;

namespace OnionArc.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : class, IBaseEntity, new()
    {
        public readonly ApplicationDbContext _context;

        public ReadRepository(ApplicationDbContext context)
        { 
            _context = context;  
        }

        private DbSet<T> Table { get => _context.Set<T>(); }

        public async Task<IList<T>> GetAllAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enableTracking = false)
        {
            IQueryable <T> queryable = Table;
            //Sadece bir okuma mekanizması kullanacağımız için, performans arttırmak için AsNoTrackingkullanıyoruz
            if (!enableTracking) queryable = queryable.AsNoTracking();

            if (include is not null) queryable = include(queryable);

            if (predicate is not null) queryable = queryable.Where(predicate);

            if (orderBy is not null)
                return await orderBy(queryable).ToListAsync();

            return await queryable.ToListAsync();

        }

        public async Task<IList<T>> GetAllAsyncByPaging(System.Linq.Expressions.Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enableTracking = false, int currentPage = 1, int pageSize = 3)
        {
            IQueryable<T> queryable = Table;

            if (!enableTracking) queryable = queryable.AsNoTracking();

            if (include is not null) queryable = include(queryable); 

            if (predicate is not null) queryable = queryable.Where(predicate);

            if (orderBy is not null)
                return await orderBy(queryable).Skip((currentPage - 1 )*pageSize).Take(pageSize).ToListAsync();

            return await queryable.Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync();
        }


        public async Task<T> GetAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate, Func<IQueryable<T>, Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<T, object>>? include = null, bool enableTracking = false)
        {
            IQueryable<T> queryable = Table;
            //Sadece bir okuma mekanizması kullanacağımız için, performans arttırmak için AsNoTrackingkullanıyoruz
            if (!enableTracking) queryable = queryable.AsNoTracking();

            if (include is not null) queryable = include(queryable);

            // queryable.Where(predicate);


            return await queryable.FirstOrDefaultAsync(predicate); 
        }


        public async Task<int> CountAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate = null)
        {
            Table.AsNoTracking();

            if (predicate is not null) Table.Where(predicate);

            return await Table.CountAsync();
        }

        public  IQueryable<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> predicate, bool enableTracking = false)
        {
            if (!enableTracking)  Table.AsNoTracking();

            return  Table.Where(predicate);
        }
    }
}

