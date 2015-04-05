using Assets.Code.CommonInterfaces;
using Assets.Code.Games.Tens.Game;
using UnityEngine;
using Debug = System.Diagnostics.Debug;

namespace Assets.Code.Games.Tens.Behaviors
{
    [RequireComponent(typeof(ICardHolder))]
    public abstract class BasePlayerBehavior : MonoBehaviour, IPlayer
    {
        protected ITensGame CurrentGame;
        protected ICardHolder HandHolder;

        public abstract void SetTurnActive();
        public abstract void GiveCard(ICard card);

        public bool ReadyToPlay
        {
            get { return true; }
        }

        public virtual void Seat(IGame game, Vector3 pos, Quaternion lookRot)
        {
            Debug.Assert(game.GetType() == typeof(ITensGame), "Tried to seat a tens player at a non tens game!");
            CurrentGame = (ITensGame)game;
            transform.position = pos;
            transform.rotation = lookRot;
        }
    }
}