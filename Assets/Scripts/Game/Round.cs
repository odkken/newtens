using UnityEngine;

namespace Assets.Scripts.Game
{
    public class Round
    {
        public BidInfo CurrentBid { get; private set; }

        public void UpdateCurrentBid(BidInfo newBid)
        {
            CurrentBid = newBid;
        }
    }
}
