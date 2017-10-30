using System;

namespace XpnMarketPlace.Business.Data.Common
{
    public interface IBaseRepositoryFactory : IDisposable
    {
        int SaveChanges();
    }
}