using System.Data.Entity;
using XpnMarketPlace.Business.Common;

namespace XpnMarketPlace.Business.Data.Common
{
    public abstract class BaseContext<TContext> : DbContext where TContext : DbContext
    {
        protected abstract void AppendModelCreating(DbModelBuilder modelBuilder);

        static BaseContext()
        {
            //Initializer isn't run when the context is created but rather when you query/add something for the first time.
            Database.SetInitializer<TContext>(new DatabaseInitializer<TContext>());
            bool instanceExists = System.Data.Entity.SqlServer.SqlProviderServices.Instance != null;
        }

        protected BaseContext()
            : base("name=XpnMarketPlace")
        {
            /* Comment Below Line Before Publishing for Better Performance */
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            AppendModelCreating(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

    }
}