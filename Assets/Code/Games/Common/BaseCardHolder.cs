using System.Collections.Generic;
using Assets.Code.CommonInterfaces;
using UnityEngine;

namespace Assets.Code.Games.Common
{
    public abstract class BaseCardHolder : ICardHolder
    {
        protected readonly Transform Transform;
        protected readonly float Width;

        protected BaseCardHolder(float width, Transform transform)
        {
            Transform = transform;
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

        protected Vector3 GetPositionForCard(int cardIndex, int totalNumCards)
        {
            var offset = Width * (cardIndex * 1.0f / (totalNumCards - 1) - .5f);
            return Transform.position + offset * Transform.right;
        }

    }
}
