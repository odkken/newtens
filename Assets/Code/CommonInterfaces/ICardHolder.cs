using System.Collections.Generic;

namespace Assets.Code.CommonInterfaces
{
    public interface ICardHolder
    {
        IEnumerable<ICard> Cards { get; }
        void AddCard(ICard card);
        ICard RemoveCard(ICard card);
        void Rearrange();
    }
}
