using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Cards;
using UnityEngine;

namespace Assets.Scripts
{
    public class Player : MonoBehaviour
    {


        public List<Card> Cards;

        public int Index { get; private set; }

        private GameRules _gameRules;
        // Use this for initialization
        void Start()
        {
            _gameRules = FindObjectOfType<GameRules>();
        }

        // Update is called once per frame
        void Update()
        {

        }



        public void GiveCard(Card card)
        {
            switch (_gameRules.ThisGameNumPlayers)
            {
                case GameRules.NumPlayers.Two:
                    if (Cards.Count(a => a.CurrentState == Card.PlayState.FaceDownOnTable) < 5)
                    {
                        card.Take(Index, Card.PlayState.FaceDownOnTable);
                    }
                    else if (Cards.Count(a => a.CurrentState == Card.PlayState.FaceUpOnTable) < 5)
                    {
                        card.Take(Index, Card.PlayState.FaceUpOnTable);
                    }
                    else if (Cards.Count(a => a.CurrentState == Card.PlayState.InHand) < 10)
                    {
                        card.Take(Index, Card.PlayState.InHand);
                    }
                    else
                    {
                        throw new Exception("Not enough room for another card!");
                    }

                    break;
                case GameRules.NumPlayers.Four:
                    if (Cards.Count(a => a.CurrentState == Card.PlayState.InHand) < 10)
                    {
                        card.Take(Index, Card.PlayState.InHand);
                    }
                    else
                    {
                        throw new Exception("Not enough room for another card!");
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }









        private int GetNextEmptyPosition()
        {
            switch (hideFlags)
            {

            }
            return 0;
        }
    }
}
