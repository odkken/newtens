using Assets.Code.Games.Common;
using UnityEngine;

namespace Assets.Code.CommonInterfaces
{
    public interface ICard
    {
        Definitions.CardSuit Suit { get; }
        Definitions.CardRank Rank { get; }
        IPlayer Owner { get; }
        void MoveTo(Vector3 pos, Quaternion rot, bool freeze);
    }
}
