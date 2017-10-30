using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using XpnMarketPlace.Business.Common;

namespace XpnMarketPlace.Business.Data.Common
{
    public abstract class RepositoryBase<T> where T : class, IObjectWithState
    {
        private readonly IUnitOfWork _unitOfWork = null;
        private readonly IDbSet<T> _dbSet = null;

        protected RepositoryBase(IUnitOfWork unitOfWork)
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
                _unitOfWork.Context.ApplyStateChanges();
            }
        }

        public IQueryable<T> GetAll
        {
            get { return _dbSet.AsNoTracking(); }
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
    }
}
