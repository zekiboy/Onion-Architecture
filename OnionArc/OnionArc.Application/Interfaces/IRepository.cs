using System;
using OnionArc.Domain.Common;

namespace OnionArc.Application.Interfaces
{
    public interface IRepository<T> where T : BaseEntity, new()
    {
        Task<List<T>> GetAsync();
        Task<T> GetByIdAsync(int Id);
        Task<T> AddAsync(T entity);
        Task<bool> DeleteAsync(int id);

    }
}

