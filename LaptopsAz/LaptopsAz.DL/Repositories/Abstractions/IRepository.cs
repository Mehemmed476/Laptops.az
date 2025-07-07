using LaptopsAz.Core.Models.Common;
using Microsoft.EntityFrameworkCore;

namespace LaptopsAz.DL.Repositories.Abstractions;

public interface IRepository<T> where T : BaseEntity, new()
{
    DbSet<T> Table { get; }
}