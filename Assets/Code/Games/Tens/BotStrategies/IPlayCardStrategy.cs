using System.Collections.Generic;
using Assets.Code.CommonInterfaces;

namespace Assets.Code.Games.Tens.BotStrategies
{
    public interface IPlayCardStrategy
    {
        ICard PickCardToPlay(IPlayer player, IEnumerable<ICard> cards, IRound round);
    }
}
