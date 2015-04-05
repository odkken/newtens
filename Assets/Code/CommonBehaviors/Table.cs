using UnityEngine;

namespace Assets
{
    public class Table : MonoBehaviour
    {
        private BoxCollider collider;



        private float HandDistance = .639f;
        private float HandHeight = 1.609f;

        private float RowDistance = .4f;

        public float Height { get { return collider.bounds.size.z; } }

        public Vector3 PlayPosition { get { return new Vector3(transform.position.x, Height + .1f, transform.position.z); } }

        //public Vector3 RowPosition(ipl.Position seatPosition)
        //{
        //    return PlayPosition - Util.RelativeForward(seatPosition) * RowDistance;
        //}

        //public Vector3 HandPosition(PlayerBehavior.Position seatPosition)
        //{
        //    return PlayPosition - Util.RelativeForward(seatPosition) * HandDistance + Vector3.up * (HandHeight - Height);
        //}

        // Use this for initialization
        void Start()
        {
            collider = GetComponentInChildren<BoxCollider>();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
