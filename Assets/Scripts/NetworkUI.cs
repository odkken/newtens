using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Assets.Scripts
{
    public class NetworkUI : MonoBehaviour
    {
        // are we currently trying to download a host list?
        private bool loading;
        private bool tryingToConnect = false;
        private string myIp;
        public string GameName = "Tens";

        //void Awake()
        //{
        //    var needToStartMasterServer = true;
        //    foreach (var prs in Process.GetProcesses())
        //    {
        //        try
        //        {
        //            if (!prs.HasExited && prs.ProcessName.Contains("MasterServer"))
        //                needToStartMasterServer = false;
        //        }
        //        catch
        //        { }
        //    }
        //    if (needToStartMasterServer)
        //    {
        //        var startInfo =
        //            new ProcessStartInfo(
        //                @"C:\Users\JJ\Downloads\MasterServer-2.0.1f1\VisualStudio\Debug\MasterServer.exe")
        //            {
        //                WindowStyle = ProcessWindowStyle.Hidden
        //            };
        //        Process.Start(startInfo);
        //    }
        //    var needToStartFacilitator = true;
        //    foreach (var prs in Process.GetProcesses())
        //    {
        //        try
        //        {
        //            if (!prs.HasExited && prs.ProcessName.Contains("Facilitator"))
        //                needToStartFacilitator = false;
        //        }
        //        catch
        //        { }
        //    }
        //    if (needToStartFacilitator)
        //    {
        //        var startInfo =
        //            new ProcessStartInfo(
        //                @"C:\Users\JJ\Downloads\fac\VisualStudio\Debug\Facilitator.exe")
        //            {
        //                WindowStyle = ProcessWindowStyle.Hidden
        //            };
        //        Process.Start(startInfo);
        //    }
        //}

        // Use this for initialization
        void Start()
        {
            //myIp = Dns.GetHostAddresses(Dns.GetHostName()).First(a => a.AddressFamily == AddressFamily.InterNetwork).ToString();

            //MasterServer.ipAddress = myIp;
            //MasterServer.port = 23466;
            //Network.natFacilitatorIP = myIp;
            //Network.natFacilitatorPort = 50005;
            RefreshHostList();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void LaunchServer()
        {
            Network.InitializeServer(8, 25005, true);
            MasterServer.RegisterHost("soup", "soup", "soup");
            GameObject.Find("UICamera").GetComponent<Camera>().enabled = false;
            GameObject.Find("GameCamera").GetComponent<Camera>().enabled = true;
        }

        void OnPlayerConnected(NetworkPlayer player)
        {
            Network.Instantiate(Resources.Load("Dealer"), Vector3.zero, Quaternion.identity, 0);
        }

        void OnServerInitialized()
        {
            Debug.Log("Server initialized");
        }

        public void JoinRandom()
        {
            if (!tryingToConnect)
                StartCoroutine(WaitForServersAndConnect());
        }

        private IEnumerator WaitForServersAndConnect()
        {
            tryingToConnect = true;
            RefreshHostList();
            while (loading)
            {
                yield return new WaitForSeconds(.1f);
            }
            var info = MasterServer.PollHostList().FirstOrDefault();

            if (info == null)
                Debug.Log("No servers found");
            else
            {
                Debug.Log("connecting to " + info.gameName);
                Network.Connect(info.ip, info.port);
                GameObject.Find("UICamera").GetComponent<Camera>().enabled = false;
                GameObject.Find("GameCamera").GetComponent<Camera>().enabled = true;
            }
            tryingToConnect = false;

        }

        void RefreshHostList()
        {
            loading = true;
            MasterServer.ClearHostList();
            MasterServer.RequestHostList(GameName);
            Debug.Log("Requesting host list");
        }

        void OnMasterServerEvent(MasterServerEvent msevent)
        {
            switch (msevent)
            {
                case MasterServerEvent.HostListReceived:
                    // received the host list, no longer awaiting results
                    Debug.Log("Received host list, gg");
                    loading = false;
                    break;
            }
        }
    }
}