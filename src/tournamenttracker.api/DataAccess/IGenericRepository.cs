using System;
using System.Linq;

namespace TournamentWebApp.DataAccess
{
    public interface IGenericRepository<T>
    {
        void Add(T item);
        IQueryable<T> GetAll();
        IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate);
        void Save();
        void Remove(T item);
    }
}