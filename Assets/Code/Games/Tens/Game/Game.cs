using System;
using System.Collections.Generic;
using Assets.Code.CommonInterfaces;

namespace Assets.Code.Games.Tens.Game
{
    public class Game : ITensGame
    {
        private readonly List<IPlayer> players;

        public IEnumerable<IPlayer> AllPlayers
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerable<IRound> AllRounds
        {
            get { throw new NotImplementedException(); }
        }

        public ITensRound CurrentRound
        {
            get { throw new NotImplementedException(); }
        }

        public void StartNewGame()
        {
            throw new NotImplementedException();
        }
    }
}
