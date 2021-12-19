using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;

namespace PharmacyService.DataAccess.DomainRepository.IRepository
{
    public interface IRepository<T> where T:class
    {
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null, int recordCount = 0);
        Task<T> GetFirstOrDefault(Expression<Func<T,bool>> filter=null, string includeProperties = null);
        Task Add(T entity);
        Task AddMany(List<T> entities);
        void Remove(int id);

        void Remove(T entity);
        IQueryable<T> where(Expression<Func<T, bool>> expression);
        Task<bool> IsValidId(Expression<Func<T, bool>> expression);
    }
}
