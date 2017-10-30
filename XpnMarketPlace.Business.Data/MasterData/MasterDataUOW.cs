using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XpnMarketPlace.Business.Data.Common;
using XpnMarketPlace.Business.Models;

namespace TUVSUD.CBW2.Business.Data.MasterData
{
    public class MasterDataUOW : UnitOfWork<MasterDataContext>
    {
        private MasterDataUOW()
            : base()
        {
        }

        public static MasterDataUOW Create()
        {
            return new MasterDataUOW();
        }
    }
}
