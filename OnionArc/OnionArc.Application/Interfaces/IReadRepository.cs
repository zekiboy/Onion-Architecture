using System;
using System.Linq.Expressions;
using OnionArc.Domain.Common;
using Microsoft.EntityFrameworkCore.Query;

namespace OnionArc.Application.Interfaces
{
	public interface IReadRepository<T>  where T : class, IBaseEntity, new()
	{

        Task<IList<T>> GetAllAsync (Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include= null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            bool enableTracking = false );



        Task<IList<T>> GetAllAsyncByPaging (Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            bool enableTracking = false, int currentPage = 1, int pageSize = 3);


        //GetAsync is enough for GetById  
        Task<T> GetAsync (Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            bool enableTracking = false);


        IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool enableTracking = false);

        Task<int> CountAsync(Expression<Func<T, bool>> predicate = null);

    }
}

