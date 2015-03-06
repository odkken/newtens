using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Assets.Scripts.Cards;
using Assets.Scripts.Common;
using Assets.Scripts.Game;
using UnityEditor;
using UnityEngine;
using Util = Assets.Scripts.Cards.Util;

namespace Assets.Scripts
{
    public class Dealer : MonoBehaviour
    {
        public static bool GenerateCards = true;
        public List<GameObject> deck;


        public GameObject bidPanel;
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
            var playerToDealTo = _gameRules.CurrentRound.PlayerToStartDealOn;
            while (deck.Any())
            {
                playerToDealTo.GiveCard(GetTopCard());
                playerToDealTo = _gameRules.GetNextPlayer(playerToDealTo);
            }
            bidPanel.SetActive(true);
        }

        private GameObject GetTopCard()
        {
            return deck.Pop();
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


                var soap = cardPrefab.transform.FindChild("Soap");
                var collider = soap.GetComponent<BoxCollider>();
                var cardThickness = collider.size.z / 2;
                var cardObject = (GameObject)Instantiate(cardPrefab, _gameRules.Table.PlayPosition + new Vector3(0, cardThickness * (cardNames.Count - iz), 0), Quaternion.LookRotation(Vector3.down, Vector3.forward));
                //cardObject.transform.SetParent(tableSurface.transform);

                deck.Add(cardObject);
                iz++;
            }

        }

    }
}
