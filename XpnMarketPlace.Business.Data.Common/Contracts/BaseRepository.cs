using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using XpnMarketPlace.Business.Common;

namespace XpnMarketPlace.Business.Data.Common
{
    public class BaseRepository<T> where T : class, IObjectWithState
    {
        protected readonly IUnitOfWork _unitOfWork = null;
        private readonly IDbSet<T> _dbSet = null;

        public BaseRepository(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null) throw new ArgumentNullException("UnitOfWork");
            _unitOfWork = unitOfWork;

            this._dbSet = _unitOfWork.Context.Set<T>();
        }

        public virtual void Create(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _dbSet.Attach(entity);
            _unitOfWork.Context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Update(T entity, IEnumerable<Expression<Func<T, object>>> toUpdateFieldNames)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _dbSet.Attach(entity);
            //_unitOfWork.Context.Entry(entity).State = EntityState.Modified;
            _unitOfWork.Context.Entry(entity).SetModified(toUpdateFieldNames);
        }

        public virtual void Delete(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            
            _dbSet.Attach(entity);
            _dbSet.Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = _dbSet.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
            {
                
                _dbSet.Attach(obj);
                _dbSet.Remove(obj);
            }
        }

        public void InsertOrUpdateGraph(T entityGraph)
        {
            if (entityGraph.State == State.Added)
            {
                _dbSet.Add(entityGraph);
            }
            else
            {
                _dbSet.Add(entityGraph);
                // NOTE: Commenting below code, will remove after through testing.
                //_unitOfWork.Context.ApplyStateChanges();
            }
        }

        public virtual IQueryable<T> GetAll
        {
            get { return _dbSet.AsNoTracking(); }
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToArrayAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> where)
        {
            return await _dbSet.AsNoTracking().Where(where).ToArrayAsync();
        }

        public T GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public T GetByIds(params object[] entityIds)
        {
            return _dbSet.Find(entityIds);
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return _dbSet.Where(where).FirstOrDefault<T>();
        }

        public IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = GetAll;
            foreach (var includeProperty in includeProperties)
                query = query.Include(includeProperty);

            return query;
        }

        /// <summary>
        /// Usage : var foo = GetBy(r => r.Id == someId, r => new { r.Id, R.Status });
        /// </summary>
        public IEnumerable<U> GetBy<U>(Expression<Func<T, bool>> exp, Expression<Func<T, U>> columns)
        {
            return _dbSet.Where<T>(exp).Select<T, U>(columns);
        }

        public int ExecuteQuery(string query)
        {
            //return _unitOfWork.Context.Database.SqlQuery<int>(query).FirstOrDefault();
            var result = _unitOfWork.Context.Database.SqlQuery<int>(query).ToList().FirstOrDefault();
            return result;
            //return _unitOfWork.Context.Database.ExecuteSqlCommand(query);
        }

        /* Overloaded version created for handling Customer Module Requirements. */
        public int ExecuteQuery(string query, int dummyParameterForOverloading)
        {
            return _unitOfWork.Context.Database.ExecuteSqlCommand(query);
        }

        public async Task<IEnumerable<U>> ExecuteQueryAsync<U>(string query) where U : class
        {
            return await _unitOfWork.Context.Database.SqlQuery<U>(query).ToArrayAsync();
        }
    }
}
