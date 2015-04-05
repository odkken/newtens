using System.Collections.Generic;
using Assets.Code.CommonInterfaces;

namespace Assets.Code.Games.Tens.Game
{
    public interface ITensGame : IGame
    {
        IEnumerable<IPlayer> AllPlayers { get; }
        IEnumerable<IRound> AllRounds { get; }
        ITensRound CurrentRound { get; }
    }
}
