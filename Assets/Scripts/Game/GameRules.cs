using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Common;
using UnityEngine;

namespace Assets.Scripts.Game
{
    public class GameRules : MonoBehaviour
    {


        public enum NumPlayers
        {
            Two,
            Four
        }

        public Table Table;

        public NumPlayers CurrentNumPlayers { get; private set; }
        public Round CurrentRound { get; private set; }
        private List<Round> allRounds = new List<Round>();

        private StateManager state;
        public bool IsGameInitialized
        {
            get
            {
                return state.CurrentGameState != StateManager.GameState.Uninitialized;
            }
        }

        public Player GetFirstPlayer()
        {
            return players[0];
        }

        public void StartNewRound()
        {
            var playerPrefab = (GameObject)Resources.Load("Player");
            switch (CurrentNumPlayers)
            {
                case GameRules.NumPlayers.Two:
                    var playerZero = (GameObject)Instantiate(playerPrefab);
                    SeatPlayer(playerZero.GetComponent<Player>());
                    var playerOne = (GameObject)Instantiate(playerPrefab);
                    SeatPlayer(playerOne.GetComponent<Player>());
                    break;
                case GameRules.NumPlayers.Four:
                    for (var i = 0; i < 4; i++)
                    {
                        var player = (GameObject)Instantiate(playerPrefab);
                        SeatPlayer(player.GetComponent<Player>());
                    }
                    break;
            }
            state.SetGameState(StateManager.GameState.Initialized);
            CurrentRound = new Round(this, GetPlayerToStartDealOn(allRounds.Count), allRounds.Count);
            allRounds.Add(CurrentRound);
            CurrentBidder = GetPlayerToStartDealOn(CurrentRound.Number);
        }


        public void SetTwoPlayer()
        {
            if (!IsGameInitialized)
                CurrentNumPlayers = NumPlayers.Two;
            else
            {
                throw new Exception("Can't change number of players while game is in progress!");
            }
        }

        public void SetFourPlayer()
        {
            if (!IsGameInitialized)
                CurrentNumPlayers = NumPlayers.Four;
            else
            {
                throw new Exception("Can't change number of players while game is in progress!");
            }
        }

        public Player CurrentBidder { get; private set; }
        public Player BidHolder { get { return CurrentRound.CurrentBid.Holder; } }

        private List<Player> players = new List<Player>();

        public Player GetPlayerByIndex(int index)
        {
            return players.Single(a => a.Index == index);
        }


        public void SeatPlayer(Player player)
        {
            switch (CurrentNumPlayers)
            {
                case NumPlayers.Two:
                    if (!players.Any())
                        player.Initialize(0, Player.Position.South);
                    else
                        player.Initialize(1, Player.Position.North);
                    break;
                case NumPlayers.Four:
                    switch (players.Count())
                    {
                        case 0:
                            player.Initialize(0, Player.Position.South);
                            break;
                        case 1:
                            player.Initialize(1, Player.Position.West);
                            break;
                        case 2:
                            player.Initialize(2, Player.Position.North);
                            break;
                        case 3:
                            player.Initialize(3, Player.Position.East);
                            break;
                    }
                    break;
            }

            player.transform.position = PositionLookup(player.SeatPosition);
            players.Add(player);
        }

        public Vector3 PositionLookup(Player.Position position)
        {
            const float magnitude = 4f;

            switch (position)
            {
                //case Player.Position.North:
                //    return tableSurface.transform.position + Vector3.up * magnitude;
                //case Player.Position.South:
                //    return tableSurface.transform.position - Vector3.up * magnitude;
                //case Player.Position.East:
                //    return tableSurface.transform.position + Vector3.right * magnitude;
                //case Player.Position.West:
                //    return tableSurface.transform.position - Vector3.right * magnitude;
            }
            return new Vector3();
        }




        // Use this for initialization
        void Start()
        {
            Table = GetComponent<Table>();
            state = GetComponent<StateManager>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public Player GetNextPlayer(Player currentPlayer)
        {
            switch (CurrentNumPlayers)
            {
                case NumPlayers.Two:

                    return players.Single(a => a.Index == 1 - currentPlayer.Index);
                case NumPlayers.Four:
                    int targetIndex;
                    if (currentPlayer.Index == 3)
                        targetIndex = 0;
                    else
                        targetIndex = currentPlayer.Index + 1;
                    return players.Single(a => a.Index == targetIndex);
                default:
                    throw new Exception("error getting next player");
            }
        }

        public void PassOnBid()
        {
            //nobody likes their cards (the next person to bid would've been the first person who bid)
            if (GetNextPlayer(CurrentBidder) == GetPlayerToStartDealOn(CurrentRound.Number))
            {
                StartNewRound();
            }

            //
            else
                CurrentBidder = GetNextPlayer(CurrentBidder);

        }

        public void SetNewBid(int amount)
        {
            CurrentRound.UpdateCurrentBid(new BidInfo { Amount = amount, Holder = CurrentBidder });
            if (amount == 100)
            {
                state.SetGameState(StateManager.GameState.Playing);
            }
            else
                CurrentBidder = GetNextPlayer(CurrentBidder);
        }


        private Player GetPlayerToStartDealOn(int roundNum)
        {
            int dealToIndex;
            switch (CurrentNumPlayers)
            {
                case NumPlayers.Two:
                    return players.Single(a => a.Index == roundNum % 2);
                    break;
                case NumPlayers.Four:
                    return players.Single(a => a.Index == roundNum % 4);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
