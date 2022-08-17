using Core.Interfaces.Repositories;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DataAccess.Repositories
{
    public class Repository<T> : IRepository<T>
        where T : class
    {
        private readonly ChatContext context;
        protected readonly DbSet<T> dbSet;

        public Repository(ChatContext context)
        {
            this.context = context;
            dbSet = this.context.Set<T>();
        }

        public async Task<IList<T>> GetAsync(
            Expression<Func<T, bool>>? filter = null, 
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, 
            bool asNoTracking = false, 
            int? take = null, int skip = 0)
        {
            IQueryable<T> query = filter == null ? 
                dbSet : dbSet.Where(filter);

            //  ᓚᘏᗢ Adding navigation properties
            if (include is not null)
                query = include(query);

            if (asNoTracking)
                query = query.AsNoTracking();

            query = query.Skip(skip);

            if (take is not null)
                query = query.Take(take.Value);

            return await query.ToListAsync();
        }

        public async ValueTask<T?> GetById(
            int id, 
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null)
        {
            T? result = await dbSet.FindAsync(id);

            if (include == null)
                return result;

            IQueryable<T> set = include(dbSet);

            return await set.FirstOrDefaultAsync(entity => entity == result);
        }

        public void Delete(T entity) =>
            dbSet.Remove(entity);

        public async Task InsertAsync(T entity) =>
            await dbSet.AddAsync(entity);

        public void Update(T entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                context.Attach(entity);
            }

            context.Entry(entity).State = EntityState.Modified;
        }

        public async Task SaveChangesAsync() =>
            await context.SaveChangesAsync();
    }
}
