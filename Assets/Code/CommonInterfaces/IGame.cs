using System.Collections.Generic;

namespace Assets.Code.CommonInterfaces
{
    interface IGame
    {
        IEnumerable<IPlayer> AllPlayers { get; }
        IEnumerable<IRound> AllRounds { get; }
        IRound CurrentRound { get; }
        void StartNewGame();
    }
}
