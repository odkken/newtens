using System.Collections.Generic;
using System.Linq;
using Assets.Code.CommonInterfaces;

namespace Assets.Code.Networking
{
    /// <summary>
    /// Used in the lobby scene to store connected players
    /// </summary>
    class PlayerManager
    {
        public IPlayer HostPlayer { get; private set; }
        private readonly List<IPlayer> connectedPlayers = new List<IPlayer>();

        public PlayerManager(IPlayer hostPlayer)
        {
            HostPlayer = hostPlayer;
            connectedPlayers.Add(hostPlayer);
        }

        public void OnPlayerJoined(IPlayer player)
        {
            connectedPlayers.Add(player);
        }

        public void OnPlayerLeft(IPlayer player)
        {
            if (connectedPlayers.Contains(player))
                connectedPlayers.Remove(player);
        }

        public bool AllPlayersReady()
        {
            return connectedPlayers.All(a => a.ReadyToPlay);
        }
    }
}
