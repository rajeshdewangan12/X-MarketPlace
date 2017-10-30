using System;

namespace XpnMarketPlace.Business.Data.Common
{
    public static class DBNullHelper
    {
        public static object ToDBNull(this object value)
        {
            return value == null ? DBNull.Value : value;
        }

        public static object ToDBNullFromString(this object value)
        {
            return value == null ? DBNull.Value : string.IsNullOrWhiteSpace(value.ToString()) == true ? DBNull.Value : value;
        }
    }
}