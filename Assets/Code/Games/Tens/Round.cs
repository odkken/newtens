using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Assets.Code.CommonInterfaces;
using Assets.Code.Games.Common;
using JetBrains.Annotations;

namespace Assets.Code.Games.Tens
{
    class Round : IRound
    {
        private IDeck deck;
        private readonly List<IPlayer> players;
        private int currentTurnPlayerIndex;
        public Round(IDeck deck, List<IPlayer> players, int dealerPlayerIndex)
        {
            IsComplete = false;

            this.deck = deck;
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

        public void PlayCard(IPlayer player, ICard card)
        {
            var playerIndex = players.IndexOf(player);
            Debug.Assert(playerIndex == currentTurnPlayerIndex, "Player " + playerIndex + " tried to play out of turn!  It's player " + currentTurnPlayerIndex + "'s turn.");
            currentTurnPlayerIndex = Util.Next(playerIndex, players.Count);
            players[currentTurnPlayerIndex].SetTurnActive();
        }
    }
}
