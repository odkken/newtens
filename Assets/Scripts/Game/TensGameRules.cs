namespace Assets.Scripts.Game
{
    //public class TensGameRules : MonoBehaviour, IGameRules
    //{


    //    public enum NumPlayers
    //    {
    //        Two,
    //        Four
    //    }

    //    public Table Table;

    //    public NumPlayers CurrentNumPlayers { get; private set; }
    //    public Round CurrentRound { get; private set; }
    //    private List<Round> allRounds = new List<Round>();

    //    private StateManager state;
    //    public bool IsGameInitialized
    //    {
    //        get
    //        {
    //            return state.CurrentGameState != StateManager.GameState.Uninitialized;
    //        }
    //    }

    //    public PlayerBehavior GetFirstPlayer()
    //    {
    //        return players[0];
    //    }

    //    public void StartNewRound()
    //    {
    //        var playerPrefab = (GameObject)Resources.Load("PlayerBehavior");
    //        switch (CurrentNumPlayers)
    //        {
    //            case NumPlayers.Two:
    //                var playerZero = (GameObject)Instantiate(playerPrefab);
    //                SeatPlayer(playerZero.GetComponent<PlayerBehavior>());
    //                var playerOne = (GameObject)Instantiate(playerPrefab);
    //                SeatPlayer(playerOne.GetComponent<PlayerBehavior>());
    //                break;
    //            case NumPlayers.Four:
    //                for (var i = 0; i < 4; i++)
    //                {
    //                    var player = (GameObject)Instantiate(playerPrefab);
    //                    SeatPlayer(player.GetComponent<PlayerBehavior>());
    //                }
    //                break;
    //        }
    //        state.SetGameState(StateManager.GameState.Initialized);
    //        CurrentRound = new Round(this, GetPlayerToStartDealOn(allRounds.Count), allRounds.Count);
    //        allRounds.Add(CurrentRound);
    //        CurrentBidder = GetPlayerToStartDealOn(CurrentRound.Number);
    //    }


    //    public void SetTwoPlayer()
    //    {
    //        if (!IsGameInitialized)
    //            CurrentNumPlayers = NumPlayers.Two;
    //        else
    //        {
    //            throw new Exception("Can't change number of players while game is in progress!");
    //        }
    //    }

    //    public void SetFourPlayer()
    //    {
    //        if (!IsGameInitialized)
    //            CurrentNumPlayers = NumPlayers.Four;
    //        else
    //        {
    //            throw new Exception("Can't change number of players while game is in progress!");
    //        }
    //    }

    //    public PlayerBehavior CurrentBidder { get; private set; }
    //    public PlayerBehavior BidHolder { get { return CurrentRound.CurrentBid.Holder; } }

    //    private List<PlayerBehavior> players = new List<PlayerBehavior>();

    //    public PlayerBehavior GetPlayerByIndex(int index)
    //    {
    //        return players.Single(a => a.Index == index);
    //    }


    //    public void StartGame(IEnumerable<PlayerBehavior> players)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public bool CanBePlayed(Card card)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void PickCardToPlay(Card card)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public PlayerBehavior CurrentTurnPlayer()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void SeatPlayer(PlayerBehavior player)
    //    {
    //        switch (CurrentNumPlayers)
    //        {
    //            case NumPlayers.Two:
    //                if (!players.Any())
    //                    player.Initialize(0, PlayerBehavior.Position.South);
    //                else
    //                    player.Initialize(1, PlayerBehavior.Position.North);
    //                break;
    //            case NumPlayers.Four:
    //                switch (players.Count())
    //                {
    //                    case 0:
    //                        player.Initialize(0, PlayerBehavior.Position.South);
    //                        break;
    //                    case 1:
    //                        player.Initialize(1, PlayerBehavior.Position.West);
    //                        break;
    //                    case 2:
    //                        player.Initialize(2, PlayerBehavior.Position.North);
    //                        break;
    //                    case 3:
    //                        player.Initialize(3, PlayerBehavior.Position.East);
    //                        break;
    //                }
    //                break;
    //        }

    //        player.transform.position = PositionLookup(player.SeatPosition);
    //        players.Add(player);
    //    }

    //    public void DealNextCard(Card card)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Vector3 PositionLookup(PlayerBehavior.Position position)
    //    {
    //        const float height = 2.771f;
    //        const float depth = .381f;

    //        return new Vector3(0, height, 0) - Util.RelativeForward(position) * depth;
    //    }




    //    // Use this for initialization
    //    void Start()
    //    {
    //        Table = GetComponent<Table>();
    //        state = GetComponent<StateManager>();
    //    }

    //    // Update is called once per frame
    //    void Update()
    //    {

    //    }

    //    public PlayerBehavior GetNextPlayer(PlayerBehavior currentPlayer)
    //    {
    //        switch (CurrentNumPlayers)
    //        {
    //            case NumPlayers.Two:

    //                return players.Single(a => a.Index == 1 - currentPlayer.Index);
    //            case NumPlayers.Four:
    //                int targetIndex;
    //                if (currentPlayer.Index == 3)
    //                    targetIndex = 0;
    //                else
    //                    targetIndex = currentPlayer.Index + 1;
    //                return players.Single(a => a.Index == targetIndex);
    //            default:
    //                throw new Exception("error getting next player");
    //        }
    //    }

    //    public void PassOnBid()
    //    {
    //        //nobody likes their cards (the next person to bid would've been the first person who bid)
    //        if (GetNextPlayer(CurrentBidder) == GetPlayerToStartDealOn(CurrentRound.Number))
    //        {
    //            StartNewRound();
    //        }

    //        //
    //        else
    //            CurrentBidder = GetNextPlayer(CurrentBidder);

    //    }

    //    public void SetNewBid(int amount)
    //    {
    //        CurrentRound.UpdateCurrentBid(new BidInfo { Amount = amount, Holder = CurrentBidder });
    //        if (amount == 100)
    //        {
    //            state.SetGameState(StateManager.GameState.Playing);
    //        }
    //        else
    //            CurrentBidder = GetNextPlayer(CurrentBidder);
    //    }


    //    private PlayerBehavior GetPlayerToStartDealOn(int roundNum)
    //    {
    //        int dealToIndex;
    //        switch (CurrentNumPlayers)
    //        {
    //            case NumPlayers.Two:
    //                return players.Single(a => a.Index == roundNum % 2);
    //                break;
    //            case NumPlayers.Four:
    //                return players.Single(a => a.Index == roundNum % 4);
    //                break;
    //            default:
    //                throw new ArgumentOutOfRangeException();
    //        }
    //    }
    //}
}
