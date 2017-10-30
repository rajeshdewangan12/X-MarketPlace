using System.Collections.Generic;
using XpnMarketPlace.Business.Models.Reference;

namespace XpnMarketPlace.Business.Models.Reference
{
    public class DashboardTaskNotificationReference
    {
        
        public IEnumerable<DashboardTaskNotificationDetail> DashboardTaskNotificationDetail { get; set; }

        public IEnumerable<DashboardAnnouncementDetail> DashboardAnnouncementDetail { get; set; }

        public DashboardTaskNotificationReference()
        {
            DashboardTaskNotificationDetail = new List<DashboardTaskNotificationDetail>();
            DashboardAnnouncementDetail = new List<DashboardAnnouncementDetail>();
        }

    }
}
