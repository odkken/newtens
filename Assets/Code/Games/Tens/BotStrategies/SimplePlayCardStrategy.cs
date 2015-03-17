using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Assets.Code.CommonInterfaces;

namespace Assets.Code.Games.Tens.BotStrategies
{
    public class SimplePlayCardStrategy : IPlayCardStrategy
    {

        public ICard PickCardToPlay(IPlayer player, IEnumerable<ICard> cards, IRound round)
        {
            var cardToPlay = cards.FirstOrDefault(round.IsPlayable);
            Debug.Assert(cardToPlay != null);
            return cardToPlay;
        }
    }
}
