using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Assets.Code.CommonInterfaces;
using UnityEngine;

namespace Assets.Code.CommonBehaviors.Networking
{
    public class ServerGetterBehavior : MonoBehaviour
    {
        public void PrintServers()
        {
            AllServers(GameType.Tens).ToList().ForEach(a => Console.WriteLine());
        }
        public IEnumerable<HostData> AllServers(GameType gameType)
        {
            MasterServer.ClearHostList();
            MasterServer.RequestHostList(gameType.ToString());
            while (!MasterServer.PollHostList().Any())
            {
                Thread.Sleep(10);
            }
            return MasterServer.PollHostList();

        }
    }
}
