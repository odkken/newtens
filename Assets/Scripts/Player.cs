using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Cards;
using Assets.Scripts.Common;
using Assets.Scripts.Game;
using UnityEngine;

namespace Assets.Scripts
{
    public class Player : MonoBehaviour
    {
        public float HorizontalTableSpacing = 1.5f;
        public float HorizontalHandSpacing = 1f;

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
            switch (_gameRules.CurrentNumPlayers)
            {
                case GameRules.NumPlayers.Two:
                    if (Cards.Count(a => a.CurrentState == Card.PlayState.FaceDownOnTable) < 5)
                    {
                        card.Take(Index, Card.PlayState.FaceDownOnTable);
                        card.MoveTo(_gameRules.PositionLookup(TablePosition) + Common.Util.RelativeRight(TablePosition) * HorizontalTableSpacing * (Cards.Count(a => a.CurrentState == Card.PlayState.FaceDownOnTable) - 2));

                    }
                    else if (Cards.Count(a => a.CurrentState == Card.PlayState.FaceUpOnTable) < 5)
                    {
                        card.Take(Index, Card.PlayState.FaceUpOnTable);
                        card.MoveTo(_gameRules.PositionLookup(TablePosition) + Common.Util.RelativeRight(TablePosition) * HorizontalTableSpacing * (Cards.Count(a => a.CurrentState == Card.PlayState.FaceUpOnTable) - 2));
                        card.transform.Rotate(Vector3.up, 180);
                    }
                    else if (Cards.Count(a => a.CurrentState == Card.PlayState.InHand) < 10)
                    {
                        card.Take(Index, Card.PlayState.InHand);
                        card.MoveTo(_gameRules.PositionLookup(TablePosition) - Common.Util.RelativeRight(TablePosition) * HorizontalHandSpacing * (Cards.Count(a => a.CurrentState == Card.PlayState.InHand) - 4.5f) - 2 * Common.Util.RelativeUp(TablePosition));
                        card.transform.Rotate(Vector3.up, 180);
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
                        card.MoveTo(_gameRules.PositionLookup(TablePosition) - Common.Util.RelativeRight(TablePosition) * HorizontalHandSpacing * (Cards.Count(a => a.CurrentState == Card.PlayState.InHand) - 4.5f) - 2 * Common.Util.RelativeUp(TablePosition));
                        card.transform.Rotate(Vector3.up, 180);
                    }
                    else
                    {
                        throw new Exception("Not enough room for another card!");
                    }
                    break;
            }
            Cards.Add(card);

            if (Cards.Count(a => a.CurrentState == Card.PlayState.InHand) == 10)
            {
                var inHandCards = Cards.Where(a => a.CurrentState == Card.PlayState.InHand);
                var suitedCards = inHandCards.GroupBy(a => a.Info.Suit).Select(a => a.ToList()).ToList();
                suitedCards.Sort((a, b) => a[0].Info.Suit.CompareTo(b[0].Info.Suit));
                if (suitedCards.Count == 3)
                {
                    if ((suitedCards[2].First().Info.Suit - suitedCards[0].First().Info.Suit) % 2 != 0)
                    {
                        suitedCards.Swap(0, 1);
                    }

                    //if the first swap didn't put the right one in the center
                    if ((suitedCards[2].First().Info.Suit - suitedCards[0].First().Info.Suit) % 2 != 0)
                    {
                        suitedCards.Swap(1, 2);
                    }
                }

                var handCards = new List<Card>();
                foreach (var suit in suitedCards)
                {
                    suit.Sort((b, a) => a.Info.Rank.CompareTo(b.Info.Rank));
                    handCards.AddRange(suit);
                }

                Cards.RemoveAll(a => a.CurrentState == Card.PlayState.InHand);
                Cards.AddRange(handCards);
                var cardThickness = cardObject.GetComponent<BoxCollider>().size.z;
                for (int i = 0; i < 10; i++)
                {
                    var cardToMove = handCards[i];
                    var destinationPos = (_gameRules.PositionLookup(TablePosition) -
                                          Common.Util.RelativeRight(TablePosition) * HorizontalHandSpacing * (i - 4.5f) -
                                          2.2f * Common.Util.RelativeUp(TablePosition));
                    destinationPos.z = _gameRules.PositionLookup(TablePosition).z + cardThickness * (i);
                    cardToMove.MoveTo(destinationPos);
                    cardToMove.transform.rotation = Quaternion.LookRotation(Vector3.back, Common.Util.RelativeUp(TablePosition));
                }
            }
        }



        private int GetNextEmptyPosition()
        {
            return 0;
        }
    }
}
