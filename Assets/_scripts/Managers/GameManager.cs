using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    public bool isGameStopped = false;
    public bool isGameover = false;

    public GameObject gameOverScreen;


    private static GameManager _instance;
    public static GameManager instance
    {
        get
        {
            if(_instance == null)
                _instance = GameObject.FindObjectOfType<GameManager>();
            return _instance;
        }
    }


    public void GameOver(){
        isGameStopped = true;
        isGameover = true;
        gameOverScreen.SetActive(true);
    }

}


