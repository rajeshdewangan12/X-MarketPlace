using System;
using XpnMarketPlace.Business.Common;

namespace XpnMarketPlace.Business.Models
{
    public class AnnouncementMaster : EntityBase
    {
        public Int64 Id { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public string IsActive { get; set; }
        
    }
}
