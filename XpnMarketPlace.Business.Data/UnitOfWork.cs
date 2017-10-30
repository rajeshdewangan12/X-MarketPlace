using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using XpnMarketPlace.Business.Common;

namespace XpnMarketPlace.Business.Data.Common
{
    public class UnitOfWork<TContext> : IUnitOfWork where TContext : DbContext, new()
    {
        protected readonly TContext _context;
        

        public UnitOfWork()
        {
            _context = new TContext();
        }

        public UnitOfWork(TContext context)
        {
            _context = context;
        }

        public DbContext Context
        {
            get { return _context; }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Clean up the managed resources.
                if (_context != null) _context.Dispose();
            }
        }

        public int Save()
        {
            try
            {
                _context.ApplyStateChanges();

                return _context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                string exceptionMessage = ex.Message;
                throw;
            }
            catch (Exception exx)
            {
                string exceptionMessage = exx.Message;
                throw;
            }
        }
    }
}