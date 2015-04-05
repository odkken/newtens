using UnityEngine;

namespace Assets.Scripts
{
    public class Dealer : MonoBehaviour
    {
    }

    //    public static bool GenerateCards = true;
    //    public List<GameObject> deck;


    //    public GameObject bidPanel;
    //    private TensGameRules tensGameRules;

    //    // Use this for initialization
    //    void Start()
    //    {
    //        tensGameRules = FindObjectOfType<TensGameRules>();
    //    }

    //    // Update is called once per frame
    //    void Update()
    //    {

    //    }

    //    public void Deal()
    //    {
    //        var playerToDealTo = tensGameRules.CurrentRound.PlayerToStartDealOn;
    //        while (deck.Any())
    //        {
    //            playerToDealTo.GiveCard(GetTopCard());
    //            playerToDealTo = tensGameRules.GetNextPlayer(playerToDealTo);
    //        }
    //        bidPanel.SetActive(true);
    //    }

    //    private GameObject GetTopCard()
    //    {
    //        return deck.Pop();
    //    }


    //    public void InitializeDeck()
    //    {
    //        var randomBytes = new byte[32];
    //        RandomNumberGenerator.Create().GetBytes(randomBytes);
    //        var shuffleSeeds = new List<int>();
    //        for (var i = 0; i < randomBytes.Count(); i += 4)
    //        {
    //            shuffleSeeds.Add(BitConverter.ToInt32(randomBytes, i));
    //        }

    //        var cardNames = new List<CardInfo>();
    //        foreach (Definitions.CardSuit suit in Enum.GetValues(typeof(Definitions.CardSuit)))
    //        {
    //            foreach (Definitions.CardRank rank in Enum.GetValues(typeof(Definitions.CardRank)))
    //            {
    //                cardNames.Add(new CardInfo { Rank = rank, Suit = suit });
    //            }
    //        }
    //        foreach (var shuffleSeed in shuffleSeeds)
    //        {
    //            cardNames.Shuffle(shuffleSeed);
    //        }

    //        var iz = 0;
    //        foreach (var card in cardNames)
    //        {
    //            GameObject cardPrefab;
    //            if (GenerateCards)
    //            {
    //                cardPrefab = (GameObject)Resources.Load("Card");
    //                Util.SetInfo(cardPrefab, card.Rank, card.Suit);
    //            }
    //            else
    //            {
    //                cardPrefab = (GameObject)Resources.Load("GeneratedCards/" + card);
    //            }


    //            var collider = cardPrefab.GetComponent<BoxCollider>();
    //            var cardThickness = collider.size.z / 2;
    //            var upDir = Code.Util.Rand.NextDouble() > .5 ? Vector3.forward : Vector3.back;
    //            var cardObject = (GameObject)Instantiate(cardPrefab, tensGameRules.Table.PlayPosition + new Vector3(0, cardThickness * (cardNames.Count - iz), 0), Quaternion.LookRotation(Vector3.down, upDir));
    //            //cardObject.transform.SetParent(tableSurface.transform);

    //            deck.Add(cardObject);
    //            iz++;
    //        }

    //    }

    //}
}
