using System;
using UnityEngine;

namespace Assets.Scripts.Game
{
    public class StateManager : MonoBehaviour
    {
        //public Dealer Dealer;

        //private TensGameRules tensGameRules;


        //public enum GameState
        //{
        //    /// <summary>
        //    /// Nothing has been initialized yet
        //    /// </summary>
        //    Uninitialized,

        //    /// <summary>
        //    /// Players have sat down and deck is initialized
        //    /// </summary>
        //    Initialized,

        //    /// <summary>
        //    /// Cards have been dealt and bidding is taking place
        //    /// </summary>
        //    Bidding,

        //    /// <summary>
        //    /// Cards are being played now until the round ends
        //    /// </summary>
        //    Playing

        //}

        //private GameState currentGameState = GameState.Uninitialized;
        //public GameState CurrentGameState { get { return currentGameState; } }
        //// Use this for initialization
        //void Start()
        //{
        //    tensGameRules = GetComponent<TensGameRules>();
        //}


        //public void SetGameState(GameState newState)
        //{
        //    switch (newState)
        //    {
        //        case GameState.Uninitialized:
        //            break;
        //        case GameState.Initialized:
        //            break;
        //        case GameState.Bidding:
        //            break;
        //        case GameState.Playing:
        //            break;
        //        default:
        //            throw new ArgumentOutOfRangeException("newState");
        //    }
        //}

        //// Update is called once per frame
        //void Update()
        //{

        //}
        //public void StartGame()
        //{
        //    Debug.Log("GameStarted");
        //    tensGameRules.StartNewRound();
        //    Dealer.InitializeDeck();
        //}
    }
}
