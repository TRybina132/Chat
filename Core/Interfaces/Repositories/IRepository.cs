using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Core.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IList<T>> GetAsync(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            bool asNoTracking = false,
            int? take = null, int skip = 0,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null);

        ValueTask<T?> GetById(
            int id,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);

        //ValueTask<T?> GetFirstOrDefaultAsync(
        //    Expression<Func<T, bool>>? filter = null,
        //    Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        //    bool asNoTracking = false);

        Task InsertAsync(T entity);

        void Update(T entity);

        void Delete(T entity);

        Task SaveChangesAsync();
    }
}
