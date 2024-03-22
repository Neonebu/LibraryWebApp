using System.Linq.Expressions;

namespace LibraryWebApp.Repository
{
    public interface IRepository<T> where T : class
    {
        T? GetByEmail(string email);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
