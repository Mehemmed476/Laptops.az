using System.Linq.Expressions;
using LaptopsAz.Core.Models.Common;

namespace LaptopsAz.DL.Repositories.Abstractions;

public interface IReadRepository<T> : IRepository<T> where T : BaseEntity, new()
{
    Task<ICollection<T>> GetAllAsync(bool isTracking = true, params string[] includes);
    Task<T> GetByIdAsync(Guid id, bool isTracking = true, params string[] includes);
    IQueryable<T> GetAllByCondition(Expression<Func<T, bool>> condition, bool isTracking = true, params string[] includes);
    IQueryable<T> GetAllByCondition(Expression<Func<T, bool>> condition, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool isTracking = true,
         params string[] includes);
    IQueryable<T> GetAllByCondition(Expression<Func<T, bool>> condition, int page, int size, bool isTracking = true,
        params string[] includes);
    Task<T> GetOneByCondition(Expression<Func<T, bool>> condition, bool isTracking = true, params string[] includes);
    Task<bool> IsExist(Guid id);
}