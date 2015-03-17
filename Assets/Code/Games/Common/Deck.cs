using System.Collections.Generic;
using System.Linq;
using Assets.Code.CommonInterfaces;

namespace Assets.Code.Games.Common
{
    class Deck : IDeck
    {
        private readonly Stack<ICard> cards;

        public Deck(IEnumerable<ICard> cards)
        {
            this.cards = new Stack<ICard>(cards);
        }

        public ICard RemoveTopCard()
        {
            return cards.Pop();
        }

        public void Shuffle(int seed)
        {
            cards.ToList().Shuffle(seed);
        }

        public int NumCardsLeft
        {
            get { return cards.Count; }
        }
    }
}
