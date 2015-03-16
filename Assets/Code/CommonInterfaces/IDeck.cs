using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Code.CommonInterfaces
{
    interface IDeck
    {
        ICard RemoveTopCard();
        void Shuffle(int seed);
        int NumCardsLeft { get; }
    }
}
