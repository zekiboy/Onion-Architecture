using System;
using OnionArc.Domain.Common;
using OnionArc.Domain.Entities;

namespace OnionArc.Application.Interfaces
{
	public interface IWriteRepository<T> where T : class , IBaseEntity, new()
    {
		Task AddAsync(T entity);

		Task AddRangeAsync (IList<T> entities);

		Task<T> UpdateAsync(T entity);

		Task HardDeleteAsync(T entity);
        Task HardDeleteRangeAsync(IList<T> entity);
    }
}

