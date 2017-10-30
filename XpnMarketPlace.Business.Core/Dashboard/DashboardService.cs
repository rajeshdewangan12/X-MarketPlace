using System.Collections.Generic;
using System.Threading.Tasks;
using XpnMarketPlace.Business.Core;
using XpnMarketPlace.Business.Models;
using XpnMarketPlace.Business.Models.Reference;

namespace TUVSUD.CBW2.Business.Core
{
    public interface IDashboardService 
    {
        DashboardTaskNotificationReference GetAnnouncementDetails();
        void UpdateNotificationAcknowledgement(string moduleID, string userName, long notificationID);
    }

    public class DashboardService : IDashboardService
    {
        private readonly IDashboardRepositoryFactory _dashboardRepositoryFactory;

        public DashboardService()
            : base()
        {
            this._dashboardRepositoryFactory = DashboardRepositoryFactory.Create();
        }
       
        public DashboardTaskNotificationReference GetAnnouncementDetails()
        {
            using (var service = _dashboardRepositoryFactory.DashboardRepository)
            {
                return service.GetAnnouncementDetails();
            }
        }

        public void UpdateNotificationAcknowledgement(string moduleID, string userName, long notificationID)
        {
            using (var service = _dashboardRepositoryFactory.DashboardRepository)
            {
                service.UpdateNotificationAcknowledgement(moduleID, userName, notificationID);
            }
        }

        public void Dispose()
        {
            if (_dashboardRepositoryFactory != null) _dashboardRepositoryFactory.Dispose();
        }

        
    }
}