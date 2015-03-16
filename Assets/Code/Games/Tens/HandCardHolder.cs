using Assets.Code.CommonInterfaces;
using Assets.Code.Games.Common;
using UnityEngine;

namespace Assets.Code.Games.Tens
{
    public class HandCardHolder : BaseCardHolder
    {
        public HandCardHolder(float width, Transform transform)
            : base(width, transform)
        {
        }
        public override void AddCard(ICard card)
        {
            card.MoveTo(GetPositionForCard((CardsList.Count) + 1, 10), Quaternion.LookRotation(Vector3.up), true);
            CardsList.Add(card);
        }

        public override ICard RemoveCard(ICard card)
        {
            var cardFromList = CardsList[CardsList.IndexOf(card)];
            CardsList.Remove(card);
            return cardFromList;
        }
    }
}
