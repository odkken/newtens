﻿using System;
using Assets.Code.CommonInterfaces;

namespace Assets.Code.Games.Tens
{
    class TwoPlayerHuman : BasePlayer
    {
        private TableCardHolder tableHolder;

        public TwoPlayerHuman(TableCardHolder tableHolder)
        {
            this.tableHolder = tableHolder;
        }

        public override void SetTurnActive()
        {
            throw new NotImplementedException();
        }

        public override void GiveCard(ICard card)
        {
            throw new NotImplementedException();
        }
    }
}
