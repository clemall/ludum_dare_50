using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    public GameObject menuScreen;

    public void pause()
    {
        GameManager.instance.isGameStopped = true;
        menuScreen.SetActive(true);
    }
    public void resume()
    {
        GameManager.instance.isGameStopped = false;
        menuScreen.SetActive(false);
    }

    public void exiting(){
        Application.Quit();
    }
}
