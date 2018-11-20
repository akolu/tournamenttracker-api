using System;
using System.Linq;
using Microsoft.Data.Entity;

namespace TournamentWebApp.DataAccess
{
    public class GenericRepository<TEntity, TContext> : IGenericRepository<TEntity>, IDisposable
           where TContext : DbContext
           where TEntity : class
    {

        private readonly TContext _context;

        public GenericRepository(TContext context)
        {
            _context = context;
        }

        public virtual void Add(TEntity item)
        {
            _context.Set<TEntity>().Add(item);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> FindBy(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        }

        public virtual void Save()
        {
            _context.SaveChanges();
        }

        public virtual void Remove(TEntity item)
        {
            _context.Set<TEntity>().Remove(item);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
