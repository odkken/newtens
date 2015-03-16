using System;
using Assets.Scripts.Game;
using UnityEngine;
using UnityEngine.UI;

namespace Assets
{
    public class BidButton : MonoBehaviour
    {
        private TensGameRules tensGameRules;
        private int amount;
        public int Amount
        {
            get { return amount; }
            private set
            {
                amount = value;
                GetComponentInChildren<Text>().text = "Bid " + amount;

                increaseButton.interactable = Amount != 100;
                decreaseButton.interactable = Amount != MinBidAmount;
            }
        }
        private int MinBidAmount { get { return Math.Max(50, tensGameRules.CurrentRound.CurrentBid.Amount + 5); } }
        private Button increaseButton;
        private Button decreaseButton;
        // Use this for initialization
        void Start()
        {
            tensGameRules = FindObjectOfType<TensGameRules>();
            increaseButton = GameObject.Find("IncreaseBidButton").GetComponent<Button>();
            decreaseButton = GameObject.Find("DecreaseBidButton").GetComponent<Button>();
            Amount = MinBidAmount;
        }

        // Update is called once per frame
        void Update()
        {

        }


        public void IncreaseBidAmount()
        {
            if (Amount + 5 <= 100)
                Amount += 5;

        }

        public void DecreaseBidAmount()
        {
            if (Amount - 5 >= MinBidAmount)
            {
                Amount -= 5;
            }
        }

        public void EnterBid()
        {
            tensGameRules.SetNewBid(Amount);
            Amount = MinBidAmount;
        }
    }
}
