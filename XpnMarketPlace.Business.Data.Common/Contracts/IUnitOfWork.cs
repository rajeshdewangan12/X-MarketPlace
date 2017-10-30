using System;
using System.Data.Entity;

namespace XpnMarketPlace.Business.Data.Common
{
    public interface IUnitOfWork : IDisposable
    {
        int Save();
        DbContext Context { get; }
    }
}
