using System.Collections;
using System.Linq;
using UnityEngine;

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
            GameObject.Find("UICamera").GetComponent<Camera>().enabled = false;
            GameObject.Find("GameCamera").GetComponent<Camera>().enabled = true;
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

        
    }
}