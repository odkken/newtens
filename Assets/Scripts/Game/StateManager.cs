using UnityEngine;

namespace Assets.Scripts.Game
{
    public class StateManager : MonoBehaviour
    {
        public Dealer Dealer;

        private GameRules gameRules;


        public enum GameState
        {
            /// <summary>
            /// Nothing has been initialized yet
            /// </summary>
            Uninitialized,

            /// <summary>
            /// Players have sat down and deck is initialized
            /// </summary>
            Initialized,

            /// <summary>
            /// Cards have been dealt and bidding is taking place
            /// </summary>
            Bidding,

            /// <summary>
            /// Cards are being played now until the round ends
            /// </summary>
            Playing

        }

        public GameState CurrentGameState = GameState.Uninitialized;

        // Use this for initialization
        void Start()
        {
            gameRules = GetComponent<GameRules>();
        }

        // Update is called once per frame
        void Update()
        {

        }
        public void StartGame()
        {
            Debug.Log("GameStarted");
            Dealer.InitializeDeck();
            gameRules.StartNewRound();
        }
    }
}
