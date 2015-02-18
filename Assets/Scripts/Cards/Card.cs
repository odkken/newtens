using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Cards
{
    public class Card : MonoBehaviour
    {
        public CardInfo Info = new CardInfo();

        public enum PlayState
        {
            InDeck,
            InHand,
            FaceDownOnTable,
            FaceUpOnTable,
            PlayedOnTable
        }


        public PlayState CurrentState { get; private set; }

        /// <summary>
        /// Indicates the player to whom the card belongs if it has not been played.
        /// If it has been played, the owner indicates the winner of the card.
        /// </summary>
        public int OwnerIndex { get; private set; }

        // Use this for initialization
        void Start()
        {
            CurrentState = PlayState.InDeck;
        }

        // Update is called once per frame
        void Update()
        {
            if (!Moving && movementQueue.Any())
            {
                var moveInfo = movementQueue.Dequeue();
                StartCoroutine(AnimateMove(moveInfo.Key, moveInfo.Value));
            }
        }

        public bool CanBeAdvanced
        {
            get
            {
                return CurrentState == PlayState.FaceUpOnTable
                       || CurrentState == PlayState.FaceDownOnTable
                       || CurrentState == PlayState.InHand;
            }
        }


        void OnMouseDown()
        {
            if (networkView.isMine && CanBeAdvanced)
                AdvanceState();
        }


        public void Take(int player, PlayState state)
        {
            if (CurrentState != PlayState.InDeck)
            {
                throw new Exception("Cannot deal a card to a player if it isn't in the deck!");
            }

            switch (state)
            {
                case PlayState.InHand:
                    break;
                case PlayState.FaceDownOnTable:
                    break;
                case PlayState.FaceUpOnTable:
                    break;
                default:
                    throw new ArgumentOutOfRangeException("state", "Bad value for new state - needs to be inhand, facedown or faceup when calling Take");
            }
            CurrentState = state;

            OwnerIndex = player;
        }

        public void Collect(int playerIndex)
        {
            OwnerIndex = playerIndex;
        }

        public void AdvanceState()
        {

            switch (CurrentState)
            {
                case PlayState.InDeck:
                    throw new Exception("Can't automatically advance from being in deck!  Need to be dealt to a player!");

                case PlayState.InHand:
                    //play the card to the table
                    CurrentState = PlayState.PlayedOnTable;
                    break;
                case PlayState.FaceDownOnTable:
                    //flip card
                    CurrentState = PlayState.FaceUpOnTable;
                    break;
                case PlayState.FaceUpOnTable:
                    //play card to the table
                    CurrentState = PlayState.PlayedOnTable;
                    break;
                case PlayState.PlayedOnTable:
                    throw new Exception("Can't automatically advance from being played on the table.  Need to be collected by a player.");
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }



        #region movement
        public bool Moving { get; private set; }
        public void MoveTo(Vector3 to)
        {
            movementQueue.Enqueue(new KeyValuePair<Vector3, float>(to, .2f));
        }

        private Queue<KeyValuePair<Vector3, float>> movementQueue = new Queue<KeyValuePair<Vector3, float>>();

        IEnumerator AnimateMove(Vector3 newPosition, float flipTime)
        {
            Moving = true;
            var startPos = transform.position;
            var time = 0f;
            while (time < 1)
            {
                time += Time.deltaTime / flipTime;
                transform.position = Vector3.Lerp(startPos, newPosition, Mathf.Log10(time * 9 + 1));
                yield return null;
            }
            transform.position = newPosition;
            Moving = false;
        }
        #endregion


    }
}
