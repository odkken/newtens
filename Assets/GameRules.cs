using System;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using System.Linq;
namespace Assets
{
    public class GameRules : MonoBehaviour
    {


        public enum NumPlayers
        {
            Two,
            Four
        }


        public NumPlayers ThisGameNumPlayers { get; private set; }

        private GameStateManager gameState;
        public bool IsGameInitialized
        {
            get
            {
                return gameState.CurrentGameState != GameStateManager.GameState.Uninitialized;
            }
        }

        public void SetTwoPlayer()
        {
            if (!IsGameInitialized)
                ThisGameNumPlayers = NumPlayers.Two;
            else
            {
                throw new Exception("Can't change number of players while game is in progress!");
            }
        }

        public void SetFourPlayer()
        {
            if (!IsGameInitialized)
                ThisGameNumPlayers = NumPlayers.Four;
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
            switch (ThisGameNumPlayers)
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
            gameState = GetComponent<GameStateManager>();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
