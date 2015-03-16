using System.Collections.Generic;
using Assets.Code.CommonInterfaces;

namespace Assets.Code.Games.Common
{
    class SimpleDealer : IDealer
    {
        private int playerIndexToDealTo;
        private readonly List<IPlayer> players;

        public SimpleDealer(List<IPlayer> players, int dealToIndex)
        {
            this.players = players;
            playerIndexToDealTo = dealToIndex;
        }

        public void DealNextCard(IDeck deck)
        {
            players[playerIndexToDealTo].GiveCard(deck.RemoveTopCard());
            playerIndexToDealTo = Util.Next(playerIndexToDealTo, players.Count);
        }

        public void DealAllCards(IDeck deck)
        {
            while (deck.NumCardsLeft > 0)
            {
                DealNextCard(deck);
            }
        }
    }
}
