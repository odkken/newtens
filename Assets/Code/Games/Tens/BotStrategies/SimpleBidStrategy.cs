using System.Collections.Generic;
using System.Linq;
using Assets.Code.CommonInterfaces;
using Assets.Code.Games.Common;

namespace Assets.Code.Games.Tens.BotStrategies
{
    class SimpleBidStrategy : IBidStrategy
    {
        public int GetBidAmount(List<ICard> cards, IRound round)
        {
            var mostInASuit = cards.GroupBy(a => a.Suit).Count();
            var numAces = cards.Count(a => a.Rank == Definitions.CardRank.Ace);
            if (mostInASuit > 4 && numAces > 2)
                return 70;
            if (mostInASuit > 3 && numAces > 1)
                return 60;
            return 50;
        }
    }
}