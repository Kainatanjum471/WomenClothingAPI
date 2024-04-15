using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WomenClothingAPI.Application.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
       Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetAllPaginated(int page, int pageSize);
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
