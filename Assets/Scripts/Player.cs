namespace Assets.Scripts
{
    //public class PlayerBehavior : MonoBehaviour
    //{
    //    private readonly float HorizontalTableSpacing = .2f;
    //    private readonly float HorizontalHandSpacing = .05f;

    //    private readonly float CardHandAngle = -60f;

    //    public enum Position
    //    {
    //        North,
    //        South,
    //        East,
    //        West
    //    }

    //    public List<Card> Cards;

    //    public int Index { get; private set; }

    //    private TensGameRules tensGameRules;
    //    // Use this for initialization
    //    void Start()
    //    {
    //        tensGameRules = FindObjectOfType<TensGameRules>();
    //    }


    //    public Position SeatPosition { get; private set; }

    //    public void Initialize(int index, Position pos)
    //    {
    //        Index = index;
    //        SeatPosition = pos;
    //    }

    //    // Update is called once per frame
    //    void Update()
    //    {

    //    }

    //    private Vector3 CardPositionInHand(int cardIndex, int totalNumCards)
    //    {
    //        var zeroPoint = tensGameRules.Table.HandPosition(SeatPosition);
    //        var handWidth = 1f;
    //        var offset = handWidth * (cardIndex * 1.0f / (totalNumCards - 1) - .5f);
    //        return zeroPoint + offset * Util.RelativeRight(SeatPosition);

    //    }


    //    public void PickCardToPlay(Card card)
    //    {
    //        if (!Cards.Contains(card))
    //            throw new Exception("Tried to play a card not owned by me: " + card.Info.Rank + "of" + card.Info.Suit + ".  Owner is player" + card.Owner.Index);
    //    }

    //    public void GiveCard(GameObject cardObject)
    //    {
    //        var card = cardObject.GetComponent<Card>();
    //        switch (tensGameRules.CurrentNumPlayers)
    //        {
    //            case TensGameRules.NumPlayers.Two:
    //                if (Cards.Count(a => a.CurrentState == Card.PlayState.FaceDownOnTable) < 5)
    //                {
    //                    card.Take(this, Card.PlayState.FaceDownOnTable);
    //                    card.MoveTo(tensGameRules.Table.RowPosition(SeatPosition) + Util.RelativeRight(SeatPosition) * HorizontalTableSpacing * (Cards.Count(a => a.CurrentState == Card.PlayState.FaceDownOnTable) - 2), Quaternion.LookRotation(Vector3.up, Util.RelativeForward(SeatPosition)), false);

    //                }
    //                else if (Cards.Count(a => a.CurrentState == Card.PlayState.FaceUpOnTable) < 5)
    //                {
    //                    card.Take(this, Card.PlayState.FaceUpOnTable);
    //                    card.MoveTo(tensGameRules.Table.RowPosition(SeatPosition) + Util.RelativeRight(SeatPosition) * HorizontalTableSpacing * (Cards.Count(a => a.CurrentState == Card.PlayState.FaceUpOnTable) - 2) + Util.RelativeForward(SeatPosition) * .02f, Quaternion.LookRotation(Vector3.down, Util.RelativeForward(SeatPosition)), false);
    //                    card.transform.Rotate(Vector3.up, 180);
    //                }
    //                else if (Cards.Count(a => a.CurrentState == Card.PlayState.InHand) < 10)
    //                {
    //                    card.Take(this, Card.PlayState.InHand);
    //                    card.MoveTo(CardPositionInHand(Cards.Count(a => a.CurrentState == Card.PlayState.InHand), 10), Quaternion.LookRotation(transform.position - card.transform.position), true);
    //                }
    //                else
    //                {
    //                    throw new Exception("Not enough room for another card!");
    //                }

    //                break;
    //            case TensGameRules.NumPlayers.Four:
    //                if (Cards.Count(a => a.CurrentState == Card.PlayState.InHand) < 10)
    //                {
    //                    card.Take(this, Card.PlayState.InHand);
    //                    card.MoveTo(CardPositionInHand(Cards.Count(a => a.CurrentState == Card.PlayState.InHand), 10), Quaternion.LookRotation(transform.position - card.transform.position), true);
    //                }
    //                else
    //                {
    //                    throw new Exception("Not enough room for another card!");
    //                }
    //                break;
    //        }
    //        Cards.Add(card);
    //        card.Owner = this;

    //        if (Cards.Count(a => a.CurrentState == Card.PlayState.InHand) == 10)
    //        {
    //            var inHandCards = Cards.Where(a => a.CurrentState == Card.PlayState.InHand);
    //            var suitedCards = inHandCards.GroupBy(a => a.Info.Suit).Select(a => a.ToList()).ToList();
    //            suitedCards.Sort((a, b) => a[0].Info.Suit.CompareTo(b[0].Info.Suit));
    //            if (suitedCards.Count == 3)
    //            {
    //                if ((suitedCards[2].First().Info.Suit - suitedCards[0].First().Info.Suit) % 2 != 0)
    //                {
    //                    suitedCards.Swap(0, 1);
    //                }

    //                //if the first swap didn't put the right one in the center
    //                if ((suitedCards[2].First().Info.Suit - suitedCards[0].First().Info.Suit) % 2 != 0)
    //                {
    //                    suitedCards.Swap(1, 2);
    //                }
    //            }

    //            var handCards = new List<Card>();
    //            foreach (var suit in suitedCards)
    //            {
    //                suit.Sort((b, a) => a.Info.Rank.CompareTo(b.Info.Rank));
    //                handCards.AddRange(suit);
    //            }

    //            handCards.Reverse();

    //            Cards.RemoveAll(a => a.CurrentState == Card.PlayState.InHand);
    //            Cards.AddRange(handCards);
    //            var cardThickness = cardObject.GetComponentInChildren<BoxCollider>().size.z;
    //            for (int i = 0; i < 10; i++)
    //            {
    //                var cardToMove = handCards[i];
    //                var destinationPos = CardPositionInHand(i, 10);
    //                destinationPos += .01f * i * (transform.position - destinationPos);
    //                //card.transform.LookAt(transform.position);
    //                //destinationPos.z = tensGameRules.PositionLookup(SeatPosition).z + cardThickness * (i);
    //                cardToMove.MoveTo(destinationPos, true);
    //                //cardToMove.transform.rotation = Quaternion.LookRotation(Vector3.back, Common.Util.RelativeForward(SeatPosition));
    //            }
    //        }
    //    }



    //    private int GetNextEmptyPosition()
    //    {
    //        return 0;
    //    }
    //}
}
