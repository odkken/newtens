using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Code.CommonInterfaces;
using Assets.Code.Games.Common;
using Assets.Code.Games.Tens.Behaviors;
using Assets.Scripts;

namespace Assets.Code
{
    /// <summary>
    /// Used for accessing prefabs
    /// </summary>
    class AssetRepository
    {
        public ICard GetCard(Definitions.CardRank rank, Definitions.CardSuit suit)
        {
            return new CardBehavior();
        }
    }
}
