using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Cards;
using UnityEngine;

namespace Assets.Scripts
{
    public class Player : MonoBehaviour
    {

        public enum Position
        {
            North,
            South,
            East,
            West
        }


        public List<Card> Cards;

        public int Index { get; private set; }

        private GameRules _gameRules;
        // Use this for initialization
        void Start()
        {
            _gameRules = FindObjectOfType<GameRules>();
        }


        public Position TablePosition { get; private set; }

        public void Initialize(int index, Position pos)
        {
            Index = index;
            TablePosition = pos;
        }

        // Update is called once per frame
        void Update()
        {

        }



        public void GiveCard(GameObject cardObject)
        {
            var card = cardObject.GetComponent<Card>();
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
            }
            cardObject.transform.position = _gameRules.PositionLookup(TablePosition);
        }



        private int GetNextEmptyPosition()
        {
            return 0;
        }
    }
}
