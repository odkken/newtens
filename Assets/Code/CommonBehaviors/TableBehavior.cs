using System.Collections.Generic;
using Assets.Code.CommonInterfaces;
using UnityEngine;

namespace Assets.Code.CommonBehaviors
{
    public class TableBehavior : MonoBehaviour
    {
        public GameCreator GameCreator;
        public IGame CurrentGame;
        public GameType Game;

        // Use this for initialization
        void Start()
        {
            GameCreator = new GameCreator();
        }

        void StartGame(IEnumerable<IPlayer> players)
        {
            CurrentGame = GameCreator.CreateGame(Game, players);
        }

    }
}
