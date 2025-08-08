using System.Linq.Expressions;
using LaptopsAz.Core.Models.Common;
using LaptopsAz.DL.Contexts;
using LaptopsAz.DL.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace LaptopsAz.DL.Repositories.Implementations;

public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity, new()
    {
        private readonly AppDbContext _context;

        public ReadRepository(AppDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<ICollection<T>> GetAllAsync(bool isTracking = true, params string[] includes)
        {
            var query = Table.AsQueryable();
            if (!isTracking)
            {
                query.AsNoTracking();
            }

            if (includes is not null && includes.Length > 0)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return await query.ToListAsync();
        }

        public IQueryable<T> GetAllByCondition(Expression<Func<T, bool>> condition, bool isTracking = true, params string[] includes)
        {
            var query = Table.Where(condition).AsQueryable();
            if (!isTracking)
            {
                query.AsNoTracking();
            }

            if (includes is not null && includes.Length > 0)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return query;
        }

        public IQueryable<T> GetAllByCondition(Expression<Func<T, bool>> condition, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool isTracking = true, params string[] includes)
        {
            var query = Table.Where(condition);
            
            if (!isTracking)
            {
                query.AsNoTracking();
            }

            if (includes is not null && includes.Length > 0)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }
            
            return query;
        }

        public IQueryable<T> GetAllByCondition(Expression<Func<T, bool>> condition, int page, int size, bool isTracking = true,
            params string[] includes)
        {
            var query = Table.Where(condition);
            
            if (!isTracking)
            {
                query.AsNoTracking();
            }

            if (includes is not null && includes.Length > 0)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            query = query.Skip(page * size).Take(size);
            
            return query;
        }

        public async Task<T> GetByIdAsync(Guid id, bool isTracking = true, params string[] includes)
        {
            var query = Table.AsQueryable();

            if (!isTracking)
            {
                query.AsNoTracking();
            }

            if (includes is not null && includes.Length > 0)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            T? entity = await query.FirstOrDefaultAsync(t => t.Id == id);
            return entity;
        }

        public async Task<T> GetOneByCondition(Expression<Func<T, bool>> condition, bool isTracking = true, params string[] includes)
        {
            var query = Table.AsQueryable();
            if (!isTracking)
            {
                query = query.AsNoTracking();
            }

            if (includes is not null && includes.Length > 0)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            T? entity = await query.FirstOrDefaultAsync(condition);
            return entity;
        }

        public async Task<bool> IsExist(Guid id)
        {
            await Table.AnyAsync(x => x.Id == id);
            return true;
        }
    }