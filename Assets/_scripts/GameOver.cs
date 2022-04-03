using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    public void startGame(){
        SceneManager.LoadScene("game");
    }

}
