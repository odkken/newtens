using Assets.Code.CommonInterfaces;
using Assets.Code.Games.Common;
using UnityEngine;

namespace Assets.Code.Games.Tens.Behaviors
{
    public class TableCardHolderBehavior : BaseCardHolderBehavior
    {
        public TableCardHolderBehavior(float width)
            : base(width)
        {
        }
        public override void AddCard(ICard card)
        {
            if (CardsList.Count < 5)
            {
                card.MoveTo(GetPositionForCard(CardsList.Count + 1, 5), Quaternion.LookRotation(Vector3.down), true);
            }
            else
            {
                card.MoveTo(GetPositionForCard((CardsList.Count - 5) + 1, 5), Quaternion.LookRotation(Vector3.up), true);
            }
            CardsList.Add(card);
        }

        public override ICard RemoveCard(ICard card)
        {
            var cardFromList = CardsList[CardsList.IndexOf(card)];
            CardsList.Remove(card);
            return cardFromList;
        }

        public override void Rearrange() { }

    }
}
