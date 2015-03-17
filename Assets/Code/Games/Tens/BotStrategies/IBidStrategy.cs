﻿using System;
using System.Collections.Generic;
using System.Text;
using Assets.Code.CommonInterfaces;

namespace Assets.Code.Games.Tens.BotStrategies
{
    interface IBidStrategy
    {
        int GetBidAmount(List<ICard> cards, IRound round);
    }
}