using Assets.Code.CommonInterfaces;
using Assets.Code.Games.Common;
using UnityEngine;

namespace Assets.Code.Games.Tens.Behaviors
{
    public class HandCardHolderBehavior : BaseCardHolderBehavior
    {
        public HandCardHolderBehavior(float width)
            : base(width)
        {
        }
        public override void AddCard(ICard card)
        {
            CardsList.Add(card);
            Rearrange();
        }

        public override ICard RemoveCard(ICard card)
        {
            var cardFromList = CardsList[CardsList.IndexOf(card)];
            CardsList.Remove(card);
            return cardFromList;
        }

        public override void Rearrange()
        {
            for (int i = 0; i < CardsList.Count; i++)
            {
                CardsList[i].MoveTo(GetPositionForCard(i, 10), Quaternion.LookRotation(Vector3.up), true);
            }
        }
    }
}
