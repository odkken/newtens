using System.Collections.Generic;
using Assets.Code.CommonInterfaces;
using UnityEngine;

namespace Assets.Code.Games.Common
{
    public abstract class BaseCardHolderBehavior : MonoBehaviour, ICardHolder
    {
        protected readonly float Width;

        protected BaseCardHolderBehavior(float width)
        {
            Width = width;
            CardsList = new List<ICard>();
        }

        protected readonly List<ICard> CardsList;

        public IEnumerable<ICard> Cards
        {
            get { return new List<ICard>(CardsList); }
        }

        public abstract void AddCard(ICard card);
        public abstract ICard RemoveCard(ICard card);
        public abstract void Rearrange();

        protected Vector3 GetPositionForCard(int cardIndex, int totalNumCards)
        {
            var offset = Width * (cardIndex * 1.0f / (totalNumCards - 1) - .5f);
            return transform.position + offset * transform.right;
        }

    }
}
