using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Assets.Scripts.Cards;
using Assets.Scripts.Common;
using UnityEngine;
using Util = Assets.Scripts.Cards.Util;

namespace Assets.Scripts
{
    public class Dealer : MonoBehaviour
    {
        public static bool GenerateCards = true;
        public List<GameObject> deck;

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

        public void Deal()
        {
            switch (_gameRules.ThisGameNumPlayers)
            {
                case GameRules.NumPlayers.Two:
                    DealTwoPlayer();
                    break;
                case GameRules.NumPlayers.Four:
                    DealFourPlayer();
                    break;
            }
        }

        private void DealTwoPlayer()
        {
            var dealToIndex = _gameRules.BidHolder.Index;
            while (deck.Any())
            {
                _gameRules.GetPlayerByIndex(dealToIndex).GiveCard(GetTopCard());
                //alternates between 1 and 0
                dealToIndex = 1 - dealToIndex;
            }
        }

        private GameObject GetTopCard()
        {
            return deck.Pop();
        }

        private void DealFourPlayer()
        {

        }

        public void InitializeDeck()
        {
            var randomBytes = new byte[32];
            RandomNumberGenerator.Create().GetBytes(randomBytes);
            var shuffleSeeds = new List<int>();
            for (var i = 0; i < randomBytes.Count(); i += 4)
            {
                shuffleSeeds.Add(BitConverter.ToInt32(randomBytes, i));
            }

            var cardNames = new List<CardInfo>();
            foreach (TensCommon.CardSuit suit in Enum.GetValues(typeof(TensCommon.CardSuit)))
            {
                foreach (TensCommon.CardRank rank in Enum.GetValues(typeof(TensCommon.CardRank)))
                {
                    cardNames.Add(new CardInfo { Rank = rank, Suit = suit });
                }
            }
            foreach (var shuffleSeed in shuffleSeeds)
            {
                cardNames.Shuffle(shuffleSeed);
            }

            var iz = 0;
            var tableSurface = GameObject.Find("TableSurface");
            foreach (var card in cardNames)
            {
                GameObject cardPrefab;
                if (GenerateCards)
                {
                    cardPrefab = (GameObject)Resources.Load("Card");
                    Util.SetInfo(cardPrefab, card.Rank, card.Suit);
                }
                else
                {
                    cardPrefab = (GameObject)Resources.Load("GeneratedCards/" + card);
                }
                var cardObject = (GameObject)Instantiate(cardPrefab, new Vector3(tableSurface.transform.position.x, tableSurface.transform.position.y, tableSurface.transform.position.z + cardPrefab.GetComponent<BoxCollider>().size.z * ((iz - cardNames.Count)) / 2), Quaternion.identity);
                cardObject.transform.SetParent(tableSurface.transform);

                deck.Add(cardObject);
                iz++;
            }

        }

    }
}
