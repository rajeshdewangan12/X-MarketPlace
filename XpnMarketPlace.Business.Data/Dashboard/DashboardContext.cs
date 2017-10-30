using System.Data.Entity;
using XpnMarketPlace.Business.Data.Common;

namespace XpnMarketPlace.Business.Data.Dashboard
{
    public class DashboardContext : BaseContext<DashboardContext>
    {
        protected override void AppendModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}