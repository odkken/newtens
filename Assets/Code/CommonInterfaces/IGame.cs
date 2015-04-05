using System.Collections.Generic;
using Assets.Code.CommonInterfaces;

namespace Assets.Code.CommonInterfaces
{
    public enum GameType
    {
        Tens,
        HighCardDraw,
        Doda
    }
    public interface IGame
    {
        void StartNewGame(IEnumerable<IPlayer> players);
    }
}
