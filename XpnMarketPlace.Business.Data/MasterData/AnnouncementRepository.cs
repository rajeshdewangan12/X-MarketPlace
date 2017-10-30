using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using XpnMarketPlace.Business.Common;
using XpnMarketPlace.Business.Data.Common;
using XpnMarketPlace.Business.Models;

namespace TUVSUD.CBW2.Business.Data.Common
{
    public class AnnouncementRepository
    {
        protected readonly IUnitOfWork _unitOfWork = null;
        //ToDo:- Instead of AnnouncementMaster replace your master model.
        private readonly IDbSet<AnnouncementMaster> _dbSet = null;

        public AnnouncementRepository(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null) throw new ArgumentNullException("UnitOfWork");
            _unitOfWork = unitOfWork;

            this._dbSet = _unitOfWork.Context.Set<AnnouncementMaster>();
        }

        public virtual void Create(AnnouncementMaster entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _dbSet.Add(entity);
        }

        public virtual void Update(AnnouncementMaster entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _dbSet.Attach(entity);
            _unitOfWork.Context.Entry(entity).State = EntityState.Modified;
        }

        public virtual IQueryable<AnnouncementMaster> GetAll
        {
            get { return _dbSet.AsNoTracking(); }
        }
    }
}
