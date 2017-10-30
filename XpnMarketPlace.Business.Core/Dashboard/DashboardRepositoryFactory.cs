using System;
using XpnMarketPlace.Business.Data.Common;
using XpnMarketPlace.Business.Data.Dashboard;
using XpnMarketPlace.Business.Models;

namespace XpnMarketPlace.Business.Core
{
    public interface IDashboardRepositoryFactory : IDisposable
    {
        IDashboardDetailRepository DashboardRepository { get; }
    }

    public class DashboardRepositoryFactory : IDashboardRepositoryFactory
    {
        private readonly IUnitOfWork _dashboardUnitOfWork;

        private DashboardRepositoryFactory()
        {
            _dashboardUnitOfWork = DashboardUOW.Create();
        }

        public static DashboardRepositoryFactory Create()
        {
            return new DashboardRepositoryFactory();
        }

        public IDashboardDetailRepository DashboardRepository
        {
            get { return new DashboardDetailRepository(); }
        }

        public void Dispose()
        {
            if (_dashboardUnitOfWork != null) _dashboardUnitOfWork.Dispose();
        }
    }
}