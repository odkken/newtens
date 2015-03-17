using System;
using System.Linq;
using Assets.Code.CommonInterfaces;
using Assets.Code.Games.Common;
using UnityEngine;
using Debug = System.Diagnostics.Debug;

namespace Assets.Code.Games.Tens.Behaviors
{
    [RequireComponent(typeof(HandCardHolderBehavior))]
    [RequireComponent(typeof(TableCardHolderBehavior))]
    public abstract class TwoPlayerBehavior : BasePlayerBehavior
    {
        protected ICardHolder TableHolder;

        public void Start()
        {
            TableHolder = GetComponent<TableCardHolderBehavior>();
            HandHolder = new SortedCardHolder(GetComponent<HandCardHolderBehavior>());
        }

        public override void GiveCard(ICard card)
        {
            Debug.Assert(TableHolder.Cards.Count() + HandHolder.Cards.Count() < 10);
            if (TableHolder.Cards.Count() < 10)
                TableHolder.AddCard(card);
            else
                HandHolder.AddCard(card);
        }

    }
}
