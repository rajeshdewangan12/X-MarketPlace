using System.Data.Entity;

namespace XpnMarketPlace.Business.Data.Common
{
    public class DatabaseInitializer<TContext> : IDatabaseInitializer<TContext>
      where TContext : DbContext
    {
        public void InitializeDatabase(TContext context)
        {
            //if (!context.Database.Exists())
            //    throw new Exception("Database does not exist");
            //else
            //{
            //    if (!context.Database.CompatibleWithModel(true))
            //    {
            //        throw new InvalidOperationException(
            //          "The database is not compatible with the entity model.");
            //    }
            //}
        }
    }
}
