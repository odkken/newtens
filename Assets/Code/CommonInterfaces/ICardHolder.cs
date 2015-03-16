using System.Collections.Generic;
using System.Security.Policy;

namespace Assets.Code.CommonInterfaces
{
    public interface ICardHolder
    {
        IEnumerable<ICard> Cards { get; }
        void AddCard(ICard card);
        ICard RemoveCard(ICard card);
    }
}
