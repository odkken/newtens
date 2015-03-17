using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Code.CommonInterfaces;

namespace Assets.Code.Games.Common
{
    class SortedCardHolder : ICardHolder
    {
        private readonly ICardHolder decoratedCardHolder;

        public SortedCardHolder(ICardHolder holder)
        {
            decoratedCardHolder = holder;
        }

        public IEnumerable<ICard> Cards
        {
            get { return decoratedCardHolder.Cards; }
        }

        public void AddCard(ICard card)
        {
            var allCards = new List<ICard>();
            while (Cards.Any())
                allCards.Add(RemoveCard(Cards.First()));
            allCards.Add(card);
            allCards.Sort(Util.CompareCards);
            foreach (var cardToAdd in allCards)
            {
                decoratedCardHolder.AddCard(cardToAdd);
            }
        }

        public ICard RemoveCard(ICard card)
        {
            return decoratedCardHolder.RemoveCard(card);
        }

        public void Rearrange()
        {
            decoratedCardHolder.Rearrange();
        }
    }
}
