using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void startGame(){
        SceneManager.LoadScene("game");
    }

    public void exiting(){
        Application.Quit();
    }
}
