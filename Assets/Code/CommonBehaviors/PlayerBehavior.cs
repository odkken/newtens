using System;
using Assets.Code.CommonInterfaces;
using UnityEngine;

namespace Assets.Code.CommonBehaviors
{
    class PlayerBehavior : MonoBehaviour, IPlayer
    {
        public void SetTurnActive()
        {
            throw new NotImplementedException();
        }

        public void GiveCard(ICard card)
        {
            throw new NotImplementedException();
        }

        public bool ReadyToPlay
        {
            get { return true; }
        }

        public void Seat(IGame game, Vector3 pos, Quaternion lookRot)
        {
            throw new NotImplementedException();
        }
    }
}