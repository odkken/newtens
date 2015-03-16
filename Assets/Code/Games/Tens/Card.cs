using System;
using Assets.Code.CommonInterfaces;
using Assets.Code.Games.Common;
using UnityEngine;

namespace Assets.Code.Games.Tens
{
    public class Card : MonoBehaviour, ICard
    {
        public Definitions.CardSuit Suit { get; private set; }
        public Definitions.CardRank Rank { get; private set; }
        public IPlayer Owner
        {
            get { throw new NotImplementedException(); }
        }

        public void MoveTo(Vector3 to, Quaternion rotation, bool freeze)
        {
            movementQueue.Enqueue(new MoveInfo()
            {
                Duration = .25f,
                To = to,
                Freeze = freeze,
                Rotation = rotation
            });
        }


    }
}
