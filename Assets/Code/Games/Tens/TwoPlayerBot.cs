using System;
using System.Diagnostics;
using System.Linq;
using Assets.Code.CommonInterfaces;

namespace Assets.Code.Games.Tens
{
    class TwoPlayerBot : BasePlayer
    {
        private readonly TableCardHolder tableHolder;

        public TwoPlayerBot(TableCardHolder tableHolder)
        {
            this.tableHolder = tableHolder;
        }

        public override void SetTurnActive()
        {
        }

        public override void GiveCard(ICard card)
        {
            Debug.Assert(tableHolder.Cards.Count() + HandHolder.Cards.Count() < 10);
            if (tableHolder.Cards.Count() < 10)
                tableHolder.AddCard(card);
            else
                HandHolder.AddCard(card);
        }
    }
}
