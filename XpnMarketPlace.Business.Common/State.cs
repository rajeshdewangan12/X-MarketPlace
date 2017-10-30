using XpnMarketPlace.Business.Common.Enums;
namespace XpnMarketPlace.Business.Common
{
    public enum State
    {
        Added,
        Unchanged,
        Modified,
        Deleted
    }

    public static class CBWStringExtension
    {
        public static string ToSystemComment(this string comment, State actionState, string isApproved)
        {
            if (actionState == State.Added)
            {
                if (string.IsNullOrWhiteSpace(comment))
                {
                    if (isApproved == "N")
                        comment = "First draft version created (System).";
                    else
                        comment = "Draft version created (System).";
                }
            }
            else if (string.IsNullOrWhiteSpace(comment))
                comment = "Draft changes saved (System).";

            return comment;
        }

        public static string ToSystemComment(this ActionStatus actionStatus)
        {
            if (actionStatus == ActionStatus.Deleted)
                return "Draft version deleted (System).";
            return "(System).";
        }

        public static string GetDefaultSystemCommentForChange(this ActionStatus actionStatus)
        {
            if (actionStatus == ActionStatus.Changed)
                return "Draft changes saved (System).";
            if (actionStatus == ActionStatus.Deleted)
                return "Draft version deleted (System).";
            return "(System).";
        }
    }
}