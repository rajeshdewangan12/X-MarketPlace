using System;

namespace XpnMarketPlace.Business.Common
{
    public abstract class EntityBase : IObjectWithState
    {
        public State State
        {
            get
            {
                if (this.OriginalHash == 0)
                    return State.Added;
                else
                {
                    if (this.OriginalHash == -1)
                        return State.Deleted;
                    if (this.Hash != this.OriginalHash && this.OriginalHash != 0)
                        return State.Modified;
                    else
                        return State.Unchanged;
                }
            }
            set
            {
                State = value;
            }
        }

        public virtual int Hash
        {
            get { return new { OriginalHash }.GetHashCode(); }
            set { Hash = value; }
        }

        public int OriginalHash { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
    }

    public abstract class EntityValidBase : EntityBase
    {
        private Nullable<DateTime> _ValidFrom;
        public Nullable<DateTime> ValidFrom
        {
            get { return _ValidFrom.HasValue ? _ValidFrom.Value.Date : _ValidFrom; }
            set { _ValidFrom = value; }
        }
        private Nullable<DateTime> _ValidUntil;
        public Nullable<DateTime> ValidUntil
        {
            get { return _ValidUntil.HasValue ? _ValidUntil.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) : _ValidUntil; }
            set { _ValidUntil = value; }
        }
    }
}