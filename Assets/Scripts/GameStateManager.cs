using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class GameStateManager : MonoBehaviour
{
    public Dealer Dealer;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
   public void StartGame()
    {
        Debug.Log("GameStarted");
        Dealer.InitializeDeck();
   
    }
}
