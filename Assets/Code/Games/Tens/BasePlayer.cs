using System;
using System.Collections.Generic;
using Assets.Code.CommonInterfaces;

namespace Assets.Code.Games.Tens
{
    public abstract class BasePlayer : IPlayer
    {
        protected HandCardHolder HandHolder;
        public abstract void SetTurnActive();
        public abstract void GiveCard(ICard card);
    }
}