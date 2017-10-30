using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XpnMarketPlace.Business.Data.Common;
using XpnMarketPlace.Business.Models;
using XpnMarketPlace.Business.Models.Mappings;

namespace TUVSUD.CBW2.Business.Data.MasterData
{
    public class MasterDataContext : BaseContext<MasterDataContext>
    {
        //ToDo:- Replace Models required according to XpnMarketPlace project
        public DbSet<AnnouncementMaster> AnnouncementMaster { get; set; }
        

        protected override void AppendModelCreating(DbModelBuilder modelBuilder)
        {
            //Replace Mapping Classess in XpnMarketPlace.Business.
            modelBuilder.Configurations.Add(new AnnouncementMasterMap());
        }
    }
}
