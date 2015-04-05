using System.Collections.Generic;
using Assets.Code.CommonInterfaces;

namespace Assets.Code.Games.HighCardDraw
{
    /// <summary>
    /// Rules: Two players sit around a shuffled deck.  One card is dealt to each player, face up.  The player with the higher card wins the pair.  If the cards are tied, the players keep their own card, but do not take the other's.
    /// This is repeated until all cards have been dealt.  The player with the most cards wins.
    /// </summary>
    class HighCardDrawGame : IGame
    {
        private IDeck deck;
        private IDealer dealer;
        public HighCardDrawGame(IDeck deck, IEnumerable<IPlayer> players)
        {
            this.deck = deck;
        }

        private IRound currentRound;
        public void StartNewGame(IEnumerable<IPlayer> players)
        {
        }
    }
}