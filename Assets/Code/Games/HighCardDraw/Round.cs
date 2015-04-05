using System;
using System.Collections.Generic;
using Assets.Code.CommonBehaviors;
using Assets.Code.CommonInterfaces;
using Assets.Code.Games.Common;

namespace Assets.Code.Games.HighCardDraw
{
    class Round : IRound
    {
        private readonly List<IPlayer> players;
        private readonly int currentTurnPlayerIndex;
        public Round(List<IPlayer> players, int dealerPlayerIndex)
        {
            IsComplete = false;

            var deck = new Deck(new List<ICard> { new CardBehavior() });
            this.players = players;
            new SimpleDealer(players, Util.Next(dealerPlayerIndex, players.Count)).DealAllCards(deck);
            currentTurnPlayerIndex = Util.Next(dealerPlayerIndex, players.Count);
        }
        public IPlayer CurrentTurnPlayer
        {
            get { return players[currentTurnPlayerIndex]; }
        }


        public IPlayer Winner
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsComplete { get; private set; }

        public bool IsPlayersTurn(IPlayer player)
        {
            return players.IndexOf(player) == currentTurnPlayerIndex;
        }

        public int Score(IPlayer player)
        {
            throw new NotImplementedException();
        }

        public bool IsPlayable(ICard card)
        {
            throw new NotImplementedException();
        }

        public void PlayCard(IPlayer player, ICard card)
        {
        }
    }
}
