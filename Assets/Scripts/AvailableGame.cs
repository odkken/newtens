using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class AvailableGame : MonoBehaviour
    {
        public HostData HostData;
        private Text gameNameText;
        private Text numPlayersText;

        void Start()
        {
            gameNameText = transform.FindChild("GameNameText").GetComponent<Text>();
            numPlayersText = transform.FindChild("NumPlayersText").GetComponent<Text>();
        }

        public void SetHostData(HostData data)
        {
            HostData = data;
            gameNameText.text = HostData.gameName;
            numPlayersText.text = "Players: " + HostData.connectedPlayers + "/" + HostData.playerLimit;
        }

        public void Join()
        {
            PanelManager.Instance.GoToPanel(GameObject.Find("TwoPlayerGamePanel").GetComponent<MovablePanel>());
            Network.Connect(HostData);
        }
    }
}
