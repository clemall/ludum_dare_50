using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    public bool stopGame = false;

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


    public void gameOver(){
        stopGame = true;
    }

    void Start(){
    }

    void Update()
    {
        if (stopGame)
        {
            gameOverScreen.SetActive(true);
        }
    }

}


