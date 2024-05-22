using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZZTicaret.Application.Repositories;
using ZZTicaret.Domain.Common;

namespace ZZTicaret.Persistence
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        public readonly ZZTicaretContext _context;

        public DbSet<T> _dbSet => _context.Set<T>();
        public Repository(ZZTicaretContext context)
        {
            _context = context;
        }

        private DbSet<T> Table { get => _context.Set<T>(); }

        public async Task<T> AddAsync(T entity)
        {
            await Table.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<int> SaveAsync()
        => await _context.SaveChangesAsync();

        public async Task<List<T>> GetAllAsync() => await Table.ToListAsync();
        public async Task<T> GetByIdAsync(Guid id) => await Table.FindAsync(id);

        public bool Update(T entity)
        {
            var entityEntry = _context.Update(entity);
            return entityEntry.State == EntityState.Modified;
        }

        public async Task<bool> Delete(Guid Id)
        {
            T entity = await _dbSet.FirstOrDefaultAsync(data => data.Id == Id);
            return Delete(entity);

        }

        public bool Delete(T entity)
        {

            EntityEntry<T> entityEntry = _dbSet.Remove(entity);
            return entityEntry.State == EntityState.Deleted;
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = Table.AsNoTracking();
            return await query.FirstOrDefaultAsync(method);
        }
    }

}