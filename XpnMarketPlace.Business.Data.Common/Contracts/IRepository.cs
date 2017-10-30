using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using XpnMarketPlace.Business.Common;

namespace TUVSUD.CBW2.Business.Data.Common
{
    public interface IRepository<T> where T : class, IObjectWithState
    {
        // MANIPULATION METHODS
        void Create(T entity);                  // Marks an entity as new
        void Update(T entity);                  // Marks an entity as modified
        void Update(T entity, IEnumerable<Expression<Func<T, object>>> toUpdateFieldNames);
        void Delete(T entity);                  // Marks an entity to be removed
        void Delete(Expression<Func<T, bool>> where);
        void InsertOrUpdateGraph(T entityGraph);

        // RETRIVAL METHODS
        IQueryable<T> GetAll { get; }           // Gets all entities of type T
        IEnumerable<U> GetBy<U>(Expression<Func<T, bool>> exp, Expression<Func<T, U>> columns);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> where);
        T GetById(object id);                   // Get an entity by id
        T GetByIds(params object[] entityIds);
        T Get(Expression<Func<T, bool>> where); // Get an entity using delegate
        IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties);
        int ExecuteQuery(string query);
    }
}
