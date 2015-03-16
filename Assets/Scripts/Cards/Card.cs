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

        private Coroutine scalingCoroutine;

        private Vector3 originalScale;
        private Vector3 mouseOverScale = new Vector3(1.5f, 1.5f, 1.5f);

        public void OnMouseEnter()
        {
            if (originalScale == Vector3.zero)
                originalScale = transform.localScale;
            if (CanBePlayed)
            {
                ScaleTo(originalScale * 1.1f);
            }
        }

        public void OnMouseExit()
        {
            ScaleTo(originalScale);
        }

        public PlayState CurrentState { get; private set; }

        /// <summary>
        /// Indicates the player to whom the card belongs if it has not been played.
        /// If it has been played, the owner indicates the winner of the card.
        /// </summary>
        public Player Owner;

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
                StartCoroutine(AnimateMove(movementQueue.Dequeue()));
            }
        }

        public bool IsFaceUp()
        {
            return Vector3.Dot(transform.forward, Vector3.up) > 0;
        }


        public bool CanBePlayed
        {
            get { return IsFaceUp() && !Moving; }
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
            if (GetComponent<NetworkView>().isMine && CanBePlayed)
                AdvanceState();
        }


        public void Take(Player player, PlayState state)
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
            Owner = player;
        }

        public void Collect(int playerIndex)
        {
            //OwnerIndex = playerIndex;
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


        struct MoveInfo
        {
            public Vector3 To;
            public float Duration;
            public bool Freeze;
            public Quaternion Rotation;
        }
        #region movement
        public bool Moving { get; private set; }
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
        public void MoveTo(Vector3 to, bool freeze)
        {
            movementQueue.Enqueue(new MoveInfo()
            {
                Duration = .25f,
                To = to,
                Freeze = freeze,
                Rotation = Quaternion.identity
            });
        }
        private Queue<MoveInfo> movementQueue = new Queue<MoveInfo>();


        public void ScaleTo(Vector3 scale)
        {
            if (scalingCoroutine != null)
                StopCoroutine(scalingCoroutine);
            scalingCoroutine = StartCoroutine(AnimateScale(scale));
        }

        IEnumerator AnimateMove(MoveInfo moveInfo)
        {
            Moving = true;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<BoxCollider>().isTrigger = true;

            var startPos = transform.position;
            var startRot = transform.rotation;
            var time = 0f;
            while (time < 1)
            {
                time += Time.deltaTime / moveInfo.Duration;
                transform.position = Vector3.Lerp(startPos, moveInfo.To, Mathf.Log10(time * 9 + 1));
                if (moveInfo.Rotation != Quaternion.identity)
                    transform.rotation = Quaternion.Slerp(startRot, moveInfo.Rotation, Mathf.Log10(time * 9 + 1));
                yield return null;
            }
            transform.position = moveInfo.To;
            if (moveInfo.Rotation != Quaternion.identity)
                transform.rotation = moveInfo.Rotation;
            Moving = false;
            if (!moveInfo.Freeze)
            {
                GetComponent<BoxCollider>().isTrigger = false;
                GetComponent<Rigidbody>().useGravity = true;
                GetComponent<Rigidbody>().isKinematic = false;
            }

        }

        IEnumerator AnimateScale(Vector3 newScale)
        {
            var startScale = transform.localScale;
            var time = 0f;
            while (time < 1)
            {
                time += Time.deltaTime / .25f;
                transform.localScale = Vector3.Lerp(startScale, newScale, Mathf.Log10(time * 9 + 1));

                yield return null;
            }
            transform.localScale = newScale;
        }

        #endregion


    }
}
