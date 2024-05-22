using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZZTicaret.Domain.Common;

namespace ZZTicaret.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> _dbSet { get; }
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<T> AddAsync(T entity);

        bool Update(T entity);
        Task<int> SaveAsync();

        bool Delete(T entity);
        Task<bool> Delete(Guid Id);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true);

       


    }
}
