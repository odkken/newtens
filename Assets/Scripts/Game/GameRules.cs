using System;
using System.Collections.Generic;
using System.Linq;
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


        public NumPlayers CurrentNumPlayers { get; private set; }
        public Round CurrentRound { get; private set; }


        private StateManager state;
        public bool IsGameInitialized
        {
            get
            {
                return state.CurrentGameState != StateManager.GameState.Uninitialized;
            }
        }

        public void StartNewRound()
        {
            var playerPrefab = (GameObject)Resources.Load("Player");
            CurrentRound = new Round();
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
            state.CurrentGameState = StateManager.GameState.Initialized;
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

        public Player BidHolder { get { return players[0]; } }


        private List<Player> players = new List<Player>();

        public Player GetPlayerByIndex(int index)
        {
            return players.Single(a => a.Index == index);
        }

        private GameObject tableSurface;

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

            player.transform.position = PositionLookup(player.TablePosition);
            players.Add(player);
        }

        public Vector3 PositionLookup(Player.Position position)
        {
            const float magnitude = 4f;

            switch (position)
            {
                case Player.Position.North:
                    return tableSurface.transform.position + Vector3.up * magnitude;
                case Player.Position.South:
                    return tableSurface.transform.position - Vector3.up * magnitude;
                case Player.Position.East:
                    return tableSurface.transform.position + Vector3.right * magnitude;
                case Player.Position.West:
                    return tableSurface.transform.position - Vector3.right * magnitude;
            }
            return new Vector3();
        }




        // Use this for initialization
        void Start()
        {
            tableSurface = GameObject.Find("TableSurface");
            state = GetComponent<StateManager>();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
