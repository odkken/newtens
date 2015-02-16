using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Assets.Scripts.Common;
using UnityEngine;
using Util = Assets.Scripts.Cards.Util;

namespace Assets.Scripts
{
    public class Dealer : MonoBehaviour
    {

        public List<GameObject> deck;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
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

            var cardNames = new List<string>();
            foreach (TensCommon.CardSuit suit in Enum.GetValues(typeof(TensCommon.CardSuit)))
            {
                foreach (TensCommon.CardRank rank in Enum.GetValues(typeof(TensCommon.CardRank)))
                {
                    cardNames.Add(rank + "of" + suit);
                }
            }
            foreach (var shuffleSeed in shuffleSeeds)
            {
                cardNames.Shuffle(shuffleSeed);
            }

            var iz = 0;
            var tableSurfacePosition = GameObject.Find("TableSurface").transform.position;
            foreach (var card in cardNames)
            {
                var cardPrefab = (GameObject)Resources.Load("GeneratedCards/" + card);
                var cardObject = (GameObject)Instantiate(cardPrefab, new Vector3(tableSurfacePosition.x, tableSurfacePosition.y, tableSurfacePosition.z + cardPrefab.GetComponent<BoxCollider>().size.z * ((iz - cardNames.Count)) / 2), Quaternion.identity);
                deck.Add(cardObject);
                iz++;
            }

        }

    }
}
