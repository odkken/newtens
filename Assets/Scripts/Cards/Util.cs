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
            card.GetComponent<Card>().Info.Rank = rank;
            card.GetComponent<Card>().Info.Suit = suit;
            var rankChar = "";
            if ((int)rank < 11)
                rankChar = ((int)rank).ToString();
            else
            {
                switch ((int)rank)
                {
                    case 11:
                        rankChar = "J";
                        break;
                    case 12:
                        rankChar = "Q";
                        break;
                    case 13:
                        rankChar = "K";
                        break;
                    case 14:
                        rankChar = "A";
                        break;
                }
            }

            if (rankChar == "")
                Debug.Log(rank + "," + (int)rank);

            var cardString = "card" + suit + rankChar;
            var frontSprite = Resources.Load<Sprite>("CardTextures/" + cardString);
            if (frontSprite == null)
                throw new Exception("Couldn't load " + cardString);
            card.transform.FindChild("Front").GetComponent<SpriteRenderer>().sprite = frontSprite;
        }
    }
}
