using XpnMarketPlace.Business.Data.Common;
using XpnMarketPlace.Business.Models;

namespace XpnMarketPlace.Business.Data.Dashboard
{
    public class DashboardUOW : UnitOfWork<DashboardContext>
    {
        private DashboardUOW()
            : base()
        {
        }

        public static DashboardUOW Create()
        {
            return new DashboardUOW();
        }
    }
}