using System;
using System.Collections.Generic;
using Assets.Code.CommonInterfaces;
using Assets.Code.Networking;
using UnityEngine;

namespace Assets.Code.CommonBehaviors.Networking
{
    public class HostBehavior : MonoBehaviour, IHost
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnServerInitialized()
        {
            Debug.Log("Server initialized");
            _isServerInitialized = true;
            MasterServer.RegisterHost(gameType.ToString(), gameName);
        }

        void OnPlayerConnected(NetworkPlayer player)
        {
            connectedPlayers.Add(player);
        }

        private static bool _isServerInitialized;

        private GameType gameType;
        private string gameName;
        public void InitializeServer(int numPlayers, GameType gameType, string gameName = "")
        {
            if (!_isServerInitialized)
            {
                this.gameType = gameType;
                if (gameName == "")
                {
                    gameName = "game " + Network.player.guid;
                }
                this.gameName = gameName;
                Network.InitializeServer(numPlayers, 25005, true);
            }
        }

        public void InitializeTensTwoPlayerServer()
        {
            InitializeServer(2, GameType.Tens);
        }

        public void DisconnectServer()
        {
            if (_isServerInitialized)
            {
                Network.Disconnect();
                MasterServer.UnregisterHost();
                _isServerInitialized = false;
            }
        }


        private readonly List<NetworkPlayer> connectedPlayers = new List<NetworkPlayer>();
        public IEnumerable<NetworkPlayer> ConnectedPlayers { get { return connectedPlayers; } }

        void OnMasterServerEvent(MasterServerEvent msevent)
        {
            switch (msevent)
            {
                case MasterServerEvent.RegistrationFailedGameName:
                    break;
                case MasterServerEvent.RegistrationFailedGameType:
                    break;
                case MasterServerEvent.RegistrationFailedNoServer:
                    break;
                case MasterServerEvent.RegistrationSucceeded:
                    Debug.Log("Successfully registered server");
                    break;
                default:
                    throw new ArgumentOutOfRangeException("msevent");
            }
        }
    }
}
