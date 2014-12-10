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
            if (networkView.isMine)
                InitializeDeck();
        }

        // Update is called once per frame
        void Update()
        {

        }

        void InitializeDeck()
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
            foreach (var card in cardNames)
            {
                deck.Add((GameObject)Network.Instantiate(Resources.Load("GeneratedCards/" + card), Vector3.zero + new Vector3(0, 0, iz * .1f), Quaternion.identity, 0));
                iz++;
            }

        }

    }
}
