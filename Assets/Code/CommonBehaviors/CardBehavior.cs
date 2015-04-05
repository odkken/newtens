using System.Collections;
using System.Collections.Generic;
using Assets.Code.CommonInterfaces;
using Assets.Code.Games.Common;
using UnityEngine;

namespace Assets.Code.CommonBehaviors
{
    public class CardBehavior : MonoBehaviour, ICard
    {

        public Definitions.CardSuit Suit { get; private set; }
        public Definitions.CardRank Rank { get; private set; }
        public IPlayer Owner { get; set; }

        private Coroutine scalingCoroutine;

        private Vector3 originalScale;

        public void OnMouseEnter()
        {
            if (originalScale == Vector3.zero)
                originalScale = transform.localScale;
            ScaleTo(originalScale * 1.05f);
        }

        public void OnMouseExit()
        {
            ScaleTo(originalScale);
        }

        struct MoveInfo
        {
            public Vector3 To;
            public float Duration;
            public bool Freeze;
            public Quaternion Rotation;
        }
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

        private readonly Queue<MoveInfo> movementQueue = new Queue<MoveInfo>();


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




    }
}
