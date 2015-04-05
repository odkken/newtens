using System;
using System.Collections.Generic;
using Assets.Code.CommonInterfaces;
using Assets.Code.Games.Common;
using Assets.Code.Games.HighCardDraw;
using Assets.Code.Games.Tens.Game;

namespace Assets.Code.CommonBehaviors
{


    public class GameCreator
    {
        void Start()
        {

        }

        public IGame CreateGame(GameType type, IEnumerable<IPlayer> players)
        {
            switch (type)
            {
                case GameType.Tens:
                    CreateTensGame(players);
                    break;
                case GameType.HighCardDraw:
                    CreateHighCardDrawGame(players);
                    break;
                case GameType.Doda:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            throw new NotImplementedException();
        }

        private void CreateHighCardDrawGame(IEnumerable<IPlayer> players)
        {
            var cards = new List<ICard>();
            foreach (Definitions.CardSuit suit in Enum.GetValues(typeof(Definitions.CardSuit)))
            {
                foreach (Definitions.CardRank rank in Enum.GetValues(typeof(Definitions.CardRank)))
                {
                    cards.Add(AssetRepository.GetCard(rank, suit));
                }
            }


            var deck = new Deck(cards);
            new HighCardDrawGame(deck, players);
        }
        private void CreateTensGame(IEnumerable<IPlayer> players)
        {
            new TensGame();
        }
    }
}
