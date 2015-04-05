using System.Collections.Generic;
using Assets.Code.CommonInterfaces;
using UnityEngine;

namespace Assets.Code.Networking
{
    interface IHost
    {
        void InitializeServer(int numPlayers, GameType gameType, string gameName);
        void DisconnectServer();
        IEnumerable<NetworkPlayer> ConnectedPlayers { get; }

    }
}
