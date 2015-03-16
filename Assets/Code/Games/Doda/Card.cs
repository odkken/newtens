using System;
using Assets.Code.CommonInterfaces;
using Assets.Code.Games.Common;
using UnityEngine;

namespace Assets.Code.Games.Doda
{
    public class Card : ICard
    {
        public bool CanBePlayed
        {
            get { throw new NotImplementedException(); }
        }

        public Definitions.CardSuit Suit
        {
            get { throw new NotImplementedException(); }
        }

        public Definitions.CardRank Rank
        {
            get { throw new NotImplementedException(); }
        }

        public IPlayer Owner
        {
            get { throw new NotImplementedException(); }
        }

        public void MoveTo(Vector3 pos, Quaternion rot, bool freeze)
        {
            throw new NotImplementedException();
        }

    }
}
