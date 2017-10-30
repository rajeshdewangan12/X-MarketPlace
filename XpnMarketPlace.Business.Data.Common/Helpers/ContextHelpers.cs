using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq.Expressions;
using XpnMarketPlace.Business.Common;

namespace XpnMarketPlace.Business.Data.Common
{
    public static class ContextHelpers
    {
        //Only use with short lived contexts
        public static void ApplyStateChanges(this DbContext context)
        {
            foreach (var entry in context.ChangeTracker.Entries<IObjectWithState>())
            {
                IObjectWithState stateInfo = entry.Entity;
                entry.State = StateHelpers.ConvertState(stateInfo.State);
            }
        }

        public static void SetModified<TEntity>(this DbEntityEntry<TEntity> entry,
                    IEnumerable<Expression<Func<TEntity, object>>> expressions) where TEntity : class
        {
            foreach (var expression in expressions)
                entry.Property(expression).IsModified = true;
        }
    }
}