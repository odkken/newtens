using System;
using System.Collections.Generic;
using System.Diagnostics;
using Assets.Code.CommonInterfaces;
using Assets.Code.Games.Common;
using Assets.Code.Games.Tens.Behaviors;

namespace Assets.Code.Games.Tens.Game
{
    class Round : ITensRound
    {
        private readonly List<IPlayer> players;
        private int currentTurnPlayerIndex;
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
            ProgressTurnToNextPlayer(player);
        }

        public BidInfo CurrentBidInfo { get; private set; }

        public Misc.RoundPhase CurrentPhase
        {
            get { throw new NotImplementedException(); }
        }

        public void EnterBid(IPlayer player, int amount)
        {
            if (amount == 0)
                ProgressTurnToNextPlayer(player);
            else
            {
                Debug.Assert(amount % 5 == 0, "Tried to bid with non-multiple of 5");
                Debug.Assert(amount >= 50, "Tried to bid less than 50");
                Debug.Assert(amount <= 100, "Tried to bid too much");
                Debug.Assert(CurrentTurnPlayer == player, "Tried to bid out of turn");
                CurrentBidInfo = new BidInfo { Amount = amount, Bidder = player };
                ProgressTurnToNextPlayer(player);
            }

        }
        private void Pass(IPlayer player)
        {

        }

        private void ProgressTurnToNextPlayer(IPlayer playerWhoJustPlayed)
        {
            AssertPlayersTurn(playerWhoJustPlayed);
            var playerIndex = players.IndexOf(playerWhoJustPlayed);
            currentTurnPlayerIndex = Util.Next(playerIndex, players.Count);
            players[currentTurnPlayerIndex].SetTurnActive();
        }

        private void AssertPlayersTurn(IPlayer player)
        {
            var playerIndex = players.IndexOf(player);
            Debug.Assert(playerIndex == currentTurnPlayerIndex, "Player " + playerIndex + " tried to play out of turn!  It's player " + currentTurnPlayerIndex + "'s turn.");
            Debug.Assert(player == CurrentTurnPlayer, "Player " + player + " tried to play out of turn!  It's player " + CurrentTurnPlayer + "'s turn.");

        }
    }
}
