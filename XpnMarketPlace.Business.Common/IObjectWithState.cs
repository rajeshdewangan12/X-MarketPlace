namespace XpnMarketPlace.Business.Common
{
    public interface IObjectWithState
    {
        State State { get; set; }
        int OriginalHash { get; set; }
    }
}