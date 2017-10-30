using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using XpnMarketPlace.Business.Data.Common;
using XpnMarketPlace.Business.Models;
using XpnMarketPlace.Business.Models.Reference;

namespace XpnMarketPlace.Business.Data.Dashboard
{
    public interface IDashboardDetailRepository : IDisposable
    {

        DashboardTaskNotificationReference GetAnnouncementDetails();
       

        void UpdateNotificationAcknowledgement(string moduleID, string userName, long notificationID);
    }

    public class DashboardDetailRepository : IDashboardDetailRepository
    {
        private readonly DashboardContext _context;

        public DashboardDetailRepository()
        {
            _context = new DashboardContext();

        }

        public DashboardTaskNotificationReference GetAnnouncementDetails()
        {
            var result = new DashboardTaskNotificationReference();

            var command = _context.Database.Connection.CreateCommand();
            command.CommandText = "APP_PROC_GetAnnouncementDetails";

            try
            {
                _context.Database.Connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    var objectContext = ((IObjectContextAdapter)_context).ObjectContext;
                    result.DashboardAnnouncementDetail = objectContext.Translate<DashboardAnnouncementDetail>(reader).ToList();
                }
            }
            finally
            {
                _context.Database.Connection.Close();
            }
            return result;
        }


        public void UpdateNotificationAcknowledgement(string moduleID, string userName, long notificationID)
        {
            string query = GetUpdateQuery(moduleID, userName, notificationID);
            if (!string.IsNullOrEmpty(query))
                _context.Database.ExecuteSqlCommand(query);
        }       
       

        private string GetUpdateQuery(string moduleID, string userName, long notificationID)
        {
            string query = string.Empty;
            if (moduleID == "ROLE_MANAGEMENT")
                query = string.Format("Update [dbo].[UM_GEN_Notifications] " +
                                        " Set [NOTIF_AcknowledgedBy]= '{0}' "
                                        + " Where [NOTIF_ID]={1} AND ([NOTIF_AcknowledgedBy] is null OR [NOTIF_AcknowledgedBy] ='')", userName, notificationID);
            else if (moduleID == "PRODUCT")
                query = string.Format("Update [dbo].[PTM_GEN_Notifications] " +
                                        " Set [NOTIF_AcknowledgedBy]= '{0}' "
                                        + " Where [NOTIF_ID]={1} AND ([NOTIF_AcknowledgedBy] is null OR [NOTIF_AcknowledgedBy] ='')", userName, notificationID);
            else if (moduleID == "CERTIFICATE_MARK")
                query = string.Format("Update [dbo].[CMARK_GEN_Notifications] " +
                                        " Set [NOTIF_AcknowledgedBy]= '{0}' "
                                        + " Where [NOTIF_ID]={1} AND ([NOTIF_AcknowledgedBy] is null OR [NOTIF_AcknowledgedBy] ='')", userName, notificationID);
            else if (moduleID == "CERTIFICATE_SETTING")
                query = string.Format("Update [dbo].[CERTSET_GEN_Notifications] " +
                                        " Set [NOTIF_AcknowledgedBy]= '{0}' "
                                        + " Where [NOTIF_ID]={1} AND ([NOTIF_AcknowledgedBy] is null OR [NOTIF_AcknowledgedBy] ='')", userName, notificationID);
            else if (moduleID == "CUSTOMER")
                query = string.Format("Update [dbo].[CUST_GEN_Notifications] " +
                                        " Set [NOTIF_AcknowledgedBy]= '{0}' "
                                        + " Where [NOTIF_ID]={1} AND ([NOTIF_AcknowledgedBy] is null OR [NOTIF_AcknowledgedBy] ='')", userName, notificationID);
            else if (moduleID == "FACILITY_SURVEILLANCE")
                query = string.Format("Update [dbo].[FCLTY_GEN_Notifications] " +
                                        " Set [NOTIF_AcknowledgedBy]= '{0}' "
                                        + " Where [NOTIF_ID]={1} AND ([NOTIF_AcknowledgedBy] is null OR [NOTIF_AcknowledgedBy] ='')", userName, notificationID);
            else if (moduleID == "AUDIT")
                query = string.Format("Update [dbo].[AUD_GEN_Notifications] " +
                                        " Set [NOTIF_AcknowledgedBy]= '{0}' "
                                        + " Where [NOTIF_ID]={1} AND ([NOTIF_AcknowledgedBy] is null OR [NOTIF_AcknowledgedBy] ='')", userName, notificationID);
            else if (moduleID == "CERTIFICATE")
                query = string.Format("Update [dbo].[CERT_GEN_Notifications] " +
                                        " Set [NOTIF_AcknowledgedBy]= '{0}' "
                                        + " Where [NOTIF_ID]={1} AND ([NOTIF_AcknowledgedBy] is null OR [NOTIF_AcknowledgedBy] ='')", userName, notificationID);


            return query;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
