using UnityEngine;

namespace Assets.Scripts
{
    public class CardInfo : MonoBehaviour
    {
        public TensCommon.CardRank Rank;
        public TensCommon.CardSuit Suit;

        private float myOffset;
        private bool oscillating = false;
        void Start()
        {

        }

        void OnMouseDown()
        {
            if (networkView.isMine)
                oscillating = !oscillating;
        }

        void Update()
        {
            if (oscillating)
            {
                transform.position = new Vector3(transform.position.x, Mathf.Sin(Time.time), transform.position.z);
            }
        }


    }

}
