using LaptopsAz.Core.Models.Common;

namespace LaptopsAz.DL.Repositories.Abstractions;

public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity, new()
{
    Task CreateAsync(T entity);
    void Delete(T entity);
    void Update(T entity);
    Task<int> SaveChangesAsync();
}