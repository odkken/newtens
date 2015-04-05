using UnityEngine;

namespace Assets.Code.CommonInterfaces
{
    public interface IPlayer
    {
        void SetTurnActive();
        void GiveCard(ICard card);
        bool ReadyToPlay { get; }
        void Seat(IGame game, Vector3 pos, Quaternion lookRot);
    }
}
