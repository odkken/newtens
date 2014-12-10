using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Cards
{
    public static class Util
    {
        public static void SetInfo(GameObject card, TensCommon.CardRank rank, TensCommon.CardSuit suit)
        {
            card.GetComponent<CardInfo>().Rank = rank;
            card.GetComponent<CardInfo>().Suit = suit;
            var rankChar = "";
            if ((int)rank < 9)
                rankChar = ((int)rank + 2).ToString();
            else
            {
                switch ((int)rank)
                {
                    case 9:
                        rankChar = "J";
                        break;
                    case 10:
                        rankChar = "Q";
                        break;
                    case 11:
                        rankChar = "K";
                        break;
                    case 12:
                        rankChar = "A";
                        break;
                }
            }

            var cardString = "card" + suit + rankChar;
            var frontSprite = Resources.Load<Sprite>("CardTextures/" + cardString);
            if (frontSprite == null)
                throw new Exception("Couldn't load " + cardString);
            card.transform.FindChild("Front").GetComponent<SpriteRenderer>().sprite = frontSprite;
        }
    }
}
