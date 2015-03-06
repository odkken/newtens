using System;
using Assets.Scripts;
using Assets.Scripts.Common;
using Assets.Scripts.Game;
using UnityEngine;

namespace Assets
{
    public class Table : MonoBehaviour
    {
        private BoxCollider collider;





        public float RowDistance = .4f;

        public float Height { get { return collider.bounds.size.z; } }

        public Vector3 PlayPosition { get { return new Vector3(transform.position.x, Height * 1.1f, transform.position.z); } }

        public Vector3 RowPosition(Player.Position seatPosition)
        {
            return PlayPosition - Util.RelativeForward(seatPosition) * RowDistance;
        }
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
