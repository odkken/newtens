using UnityEngine;

namespace Assets.Code.CommonInterfaces
{
    public interface IPlayer
    {
        void SetTurnActive();
        void GiveCard(ICard card);

        void Seat(IGame game, Vector3 pos, Quaternion lookRot);
    }
}
