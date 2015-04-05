using Assets.Code.CommonInterfaces;

namespace Assets.Code.Games.Tens.Game
{
    public interface ITensRound : IRound
    {
        BidInfo CurrentBidInfo { get; }
        Misc.RoundPhase CurrentPhase { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        /// <param name="amount">0 for pass</param>
        void EnterBid(IPlayer player, int amount);
    }
}
